
using Newtonsoft.Json;

namespace Public.DTO.v1;

public class CoursesDTO
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    [JsonProperty("courseName")]
    public string? CourseName { get; set; }
    [JsonProperty("courseCode")]
    public string? CourseCode { get; set; }
}