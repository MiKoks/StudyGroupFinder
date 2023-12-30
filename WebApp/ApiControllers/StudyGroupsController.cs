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
using Helpers.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Public.DTO.Mappers;
using Public.DTO.v1;
using Courses = BLL.DTO.Courses;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Controller for managing study groups.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudyGroupsController : ControllerBase
    {
        
        private readonly StudyGroupsMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudyGroupsController"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uow"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public StudyGroupsController(IMapper autoMapper, IAppBLL bll)
        {
            
            _bll = bll;
            _mapper = new StudyGroupsMapper(autoMapper);
        }

        // GET: api/StudyGroups
        /// <summary>
        /// Retrieves a list of study groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudyGroupsDTO>>> GetStudyGroups()
        {
            var data = await _bll.StudyGroupsService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/StudyGroups/5
        /// <summary>
        /// Retrieves details of a specific study group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyGroupsDTO>> GetStudyGroups(Guid id)
        {
            var studyGroups = await _bll.StudyGroupsService.FindAsync(id);

            if (studyGroups == null)
            {
                return NotFound();
            }

            return _mapper.Map(studyGroups)!;
        }

        // PUT: api/StudyGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a study group.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studyGroups"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudyGroups(Guid id, StudyGroupsDTO studyGroups)
        {
            if (id != studyGroups.Id)
            {
                return BadRequest();
            }

            var bllStudyGroups = _mapper.Map(studyGroups);
            _bll.StudyGroupsService.Update(bllStudyGroups!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/StudyGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new study group.
        /// </summary>
        /// <param name="studyGroups"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<StudyGroupsDTO>> PostStudyGroups(StudyGroupsDTO studyGroups)
        {
            studyGroups.Id = Guid.NewGuid();
            if (studyGroups.CourseId.Equals(null) || studyGroups.CourseId.Equals(Guid.Empty))
            {
                return BadRequest($"CoursesIDs invalid {studyGroups.CourseId}");
            }
            
            var bllStudyGroups = _mapper.Map(studyGroups);
            bllStudyGroups!.AppUserId = User.GetUserId();
            bllStudyGroups!.CourseId = studyGroups.CourseId;

            _bll.StudyGroupsService.Add(bllStudyGroups!);
            await _bll.SaveChangesAsync();

          return CreatedAtAction("GetStudyGroups", new { id = studyGroups.Id }, studyGroups);
        }

        // DELETE: api/StudyGroups/5
        /// <summary>
        ///  Deletes a study group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudyGroups(Guid id)
        {
            var studyGroupss = await _bll.UserStudyGroupsService.GetAllForStudyGroupAsync(id);
            
            foreach (var userStudyGroup in studyGroupss)
            {
                userStudyGroup.StudyGroupsId = null;
                _bll.UserStudyGroupsService.Update(userStudyGroup);
            }
            
            var studyGroups = await _bll.StudyGroupsService.RemoveAsync(id);
            if (studyGroups == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
