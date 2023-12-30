using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using BLL.DTO;
using Contracts.Base;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.Mappers;
using Public.DTO.v1;

namespace WebApp.ApiControllers;

/// <summary>
/// Controller handling Courses
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CoursesController : ControllerBase
{
    private readonly IAppBLL _bll;
    private readonly CoursesMapper _mapper;

    /// <summary>
    /// Constructor for CoursesController
    /// </summary>
    /// <param name="autoMapper"></param>
    /// <param name="bll"></param>
    public CoursesController(IMapper autoMapper, IAppBLL bll)
    {
        _bll = bll;
        _mapper = new CoursesMapper(autoMapper);
    }

    // GET: api/Courses
    /// <summary>
    /// Get a list of all courses
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(IEnumerable<CoursesDTO>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CoursesDTO>>> GetCourses()
    {
        var data = await _bll.CoursesService.AllAsync();
        
        var res = data
            .Select(e => _mapper.Map(e)!)
            .ToList();
        
        return res;
    }

    // GET: api/Courses/5
    /// <summary>
    /// Get a specific course by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CoursesDTO>> GetCourses(Guid id)
    {
        var courses = await _bll.CoursesService.FindAsync(id);

        if (courses == null)
        {
            return NotFound();
        }

        var res = _mapper.Map(courses)!;
        return res;
    }

    // PUT: api/Courses/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Update an existing course
    /// </summary>
    /// <param name="id"></param>
    /// <param name="courses"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CoursesDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
    public async Task<IActionResult> PutCourses(Guid id, CoursesDTO courses)
    {
        if (id != courses.Id)
        {
            return BadRequest();
        }

        var bllCourses = _mapper.Map(courses);
        if (bllCourses != null)
        {
            _bll.CoursesService.Update(bllCourses);
            
        } 
        await _bll.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/Courses
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    /// <summary>
    /// Create a new course
    /// </summary>
    /// <param name="courses"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CoursesDTO>> PostCourses(CoursesDTO courses)
    {
        courses.Id = Guid.NewGuid();
        var bllCourses = _mapper.Map(courses);
        if (bllCourses != null) _bll.CoursesService.Add(bllCourses);
        await _bll.SaveChangesAsync();

        return CreatedAtAction("GetCourses", new { id = courses.Id }, courses);
    }

    // DELETE: api/Courses/5
    /// <summary>
    /// Delete a specific course by its ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourses(Guid id)
    {
        var courses = await _bll.CoursesService.RemoveAsync(id);
        if (courses == null)
        {
            return NotFound();
        }
        await _bll.SaveChangesAsync();

        return NoContent();
    }
}

