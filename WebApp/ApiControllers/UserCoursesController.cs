using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using AutoMapper;
using BLL.Contracts.App;
using DAL.Contracts.App;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.EF.App;
using Domain.App;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.Mappers;
using Public.DTO.v1;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Controller for managing user courses.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserCoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserCoursesMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCoursesController"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uow"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public UserCoursesController(ApplicationDbContext context, IAppUOW uow, IMapper autoMapper, IAppBLL bll)
        {
            _context = context;
            _bll = bll;
            _mapper = new UserCoursesMapper(autoMapper);
        }

        // GET: api/UserCourses
        /// <summary>
        /// Retrieves a list of user courses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCoursesDTO>>> GetUserCourses()
        {
            var data = await _bll.UserCoursesService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/UserCourses/5
        /// <summary>
        /// Retrieves details of a specific user course.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCoursesDTO>> GetUserCourses(Guid id)
        {
            var userCourses = await _bll.UserCoursesService.FindAsync(id);

            if (userCourses == null)
            {
                return NotFound();
            }

            return _mapper.Map(userCourses)!;
        }

        // PUT: api/UserCourses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a user course.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userCourses"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCourses(Guid id, UserCoursesDTO userCourses)
        {
            if (id != userCourses.Id)
            {
                return BadRequest();
            }

            var bllUserCourses = _mapper.Map(userCourses);
            _bll.UserCoursesService.Update(bllUserCourses!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UserCourses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new user course.
        /// </summary>
        /// <param name="userCourses"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserCoursesDTO>> PostUserCourses(UserCoursesDTO userCourses)
        {
            var bllUserCourses = _mapper.Map(userCourses);
            _bll.UserCoursesService.Add(bllUserCourses!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserCourses", new { id = userCourses.Id }, userCourses);
        }

        // DELETE: api/UserCourses/5
        /// <summary>
        /// Deletes a user course.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCourses(Guid id)
        {
            var userCourses = await _bll.UserCoursesService.RemoveAsync(id);
            if (userCourses == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
