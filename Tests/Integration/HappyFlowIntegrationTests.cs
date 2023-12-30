using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using BLL.DTO;
using DAL.EF.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Public.DTO.v1.Identity;
using Tests.Helpers;
using Xunit.Abstractions;
using AppRole = Domain.App.Identity.AppRole;
using AppUser = Domain.App.Identity.AppUser;
using Courses = Domain.App.Courses;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Tests.Integration;

public class HappyFlowIntegrationTests : IClassFixture<CustomWebAppFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebAppFactory<Program> _factory;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly AutoTestIdentityHelper _autoTestIdentityHelper;
    private readonly LogTextGenerator _logTextGenerator;

    //private const string StudyGroupsUrl = "/api/v1/studygroups";
    private readonly ITestOutputHelper _outputHelper;
    private readonly UserDataFlowAppSeed TestData;

    private readonly JsonSerializerOptions camelCaseJsonSerializerOptions = new JsonSerializerOptions()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public HappyFlowIntegrationTests(CustomWebAppFactory<Program> factory, ITestOutputHelper testOutputHelper, ITestOutputHelper outputHelper)
    {
        _factory = factory;
        _testOutputHelper = testOutputHelper;
        _outputHelper = outputHelper;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
        _logTextGenerator = new LogTextGenerator(_testOutputHelper);
        _autoTestIdentityHelper = new AutoTestIdentityHelper(_client, _logTextGenerator);

        using (var scope = _factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var userManager = scopedServices.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scopedServices.GetRequiredService<RoleManager<AppRole>>();
            var db = scopedServices.GetRequiredService<ApplicationDbContext>();

            TestData =
                new UserDataFlowAppSeed(userManager, roleManager, db);

            _testOutputHelper.WriteLine("Seed data");
        }
    }

    [Fact(DisplayName = "User study group creation flow")]
    public async Task CustomerCreatesOrderFlowTestCase()
    {
        const string URL = "/api/v1/identity/account/register?expiresInSeconds=1";
        
        _testOutputHelper.WriteLine("1. Register user");
        var userEmail = "apptest9999@app.com";
        var userPassword = "Mihkel.1";
        var firstName = "App";
        var lastName = "Test";
        var jwt = await _autoTestIdentityHelper.RegisterNewUser(userEmail, userPassword, firstName, lastName);
        var jwtResponse = JsonSerializer.Deserialize<JWTResponse>(jwt, camelCaseJsonSerializerOptions);
        var registeredUserId = _autoTestIdentityHelper.GetUserIdFromJwt(jwtResponse!.JWT);

        _testOutputHelper.WriteLine("2. Create study group");
        
        var Courserequest = new HttpRequestMessage(HttpMethod.Get, "/api/v1/Courses");
        Courserequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse!.JWT);
        Courserequest.Headers.Add("accept", "application/json");
        Console.WriteLine("REQUEST:{0}\n", JsonSerializer.Serialize(Courserequest));
            
        var Courseresponse = await _client.SendAsync(Courserequest);
        _logTextGenerator.GenerateHttpRequestResponseLog(Courseresponse);
        Courseresponse.EnsureSuccessStatusCode();
        Console.WriteLine(await Courseresponse.Content.ReadAsStringAsync());
        
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/api/v1/StudyGroups");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse!.JWT);
        request.Headers.Add("accept", "text/plain");
        Console.WriteLine(await Courseresponse.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK ,Courseresponse.StatusCode);
        
        var coursesResponseData =
            JsonSerializer.Deserialize<List<Courses>>(
                await Courseresponse.Content.ReadAsStreamAsync(),
                new CustomJsonSerializerOptions().CamelCaseJsonSerializerOptions);
        var studyGroups = new StudyGroups
        {
            Id = Guid.NewGuid(),
            GroupName = "Füüsika grupp",
            Description = "Füüsika õppimine koolis",
            CourseId = coursesResponseData!.First().Id,
            MeetingTimes = "String",
            Location = "String",
            MaxGroupSize = 3,
            CreatedAt = DateTime.Now,
        };

        request.Content = new StringContent(JsonSerializer.Serialize(studyGroups), Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        _testOutputHelper.WriteLine("2. log out");
        await Logout(jwtResponse);
    }
    
    
    
    public async Task<string> Logout(JWTResponse jwtResponse)
    {
        var URL = "/api/v1/identity/account/Logout";

        var loginData = new Logout
        {
            RefreshToken = jwtResponse.RefreshToken
        };

        var data = JsonContent.Create(loginData);

        var request = new HttpRequestMessage(HttpMethod.Post, URL);
        request.Content = JsonContent.Create(loginData);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse!.JWT);
        var response = await _client.SendAsync(request);
        _logTextGenerator.GenerateHttpRequestResponseLog(response);


        // Assert
        Assert.True(response.IsSuccessStatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }

    
    
    /*private async Task<(HttpResponseMessage response, TType? actualElements)> SendGetRequest<TType>(string url,
        JWTResponse jwtResponse)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtResponse!.JWT);
        var response = await _client.SendAsync(request);

        _logTextGenerator.GenerateHttpRequestResponseLog(response);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var actualElements = JsonSerializer.Deserialize<TType>(
            await response.Content.ReadAsStreamAsync());
            

        return (response, actualElements);
    }*/
    
    public class CustomJsonSerializerOptions
    {
        public readonly JsonSerializerOptions CamelCaseJsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
    
    private void VerifyJwtContent(string jwt, string email, DateTime validToIsSmallerThan)
    {
        var jwtResponse = JsonSerializer.Deserialize<JWTResponse>(jwt, camelCaseJsonSerializerOptions);

        Assert.NotNull(jwtResponse);
        Assert.NotNull(jwtResponse.RefreshToken);
        Assert.NotNull(jwtResponse.JWT);

        // verify the actual JWT
        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(jwtResponse.JWT);
        Assert.Equal(email, jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
        // Assert.Equal(firstname, jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value);
        // Assert.Equal(lastname, jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value);
        Assert.True(jwtToken.ValidTo < validToIsSmallerThan);
    }
    
    
    
}