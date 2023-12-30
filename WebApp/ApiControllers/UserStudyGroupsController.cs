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
    /// Controller for managing user study groups.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserStudyGroupsController : ControllerBase
    {
        
        private readonly UserStudyGroupsMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStudyGroupsController"/> class.
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public UserStudyGroupsController(IMapper autoMapper, IAppBLL bll)
        {
            _bll = bll;
            _mapper = new UserStudyGroupsMapper(autoMapper);
        }

        // GET: api/UserStudyGroups
        /// <summary>
        /// Retrieves a list of user study groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserStudyGroupsDTO>>> GetUserStudyGroups()
        {
            var data = await _bll.UserStudyGroupsService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/UserStudyGroups/5
        /// <summary>
        /// Retrieves details of a specific user study group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserStudyGroupsDTO>> GetUserStudyGroups(Guid id)
        {
            var userStudyGroups = await _bll.UserStudyGroupsService.FindAsync(id);

            if (userStudyGroups == null)
            {
                return NotFound();
            }

            return _mapper.Map(userStudyGroups)!;
        }

        // PUT: api/UserStudyGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a user study group.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userStudyGroups"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStudyGroups(Guid id, UserStudyGroupsDTO userStudyGroups)
        {
            if (id != userStudyGroups.Id)
            {
                return BadRequest();
            }

            var bllUserStudyGroups = _mapper.Map(userStudyGroups);
            _bll.UserStudyGroupsService.Update(bllUserStudyGroups!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UserStudyGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new user study group.
        /// </summary>
        /// <param name="userStudyGroups"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserStudyGroupsDTO>> PostUserStudyGroups(UserStudyGroupsDTO userStudyGroups)
        {
            var bllUserStudyGroups = _mapper.Map(userStudyGroups);
            _bll.UserStudyGroupsService.Add(bllUserStudyGroups!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserStudyGroups", new { id = userStudyGroups.Id }, userStudyGroups);
        }

        // DELETE: api/UserStudyGroups/5
        /// <summary>
        /// Deletes a user study group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserStudyGroups(Guid id)
        {
            var studyGroups = await _bll.UserStudyGroupsService.GetAllForStudyGroupAsync(id);
            
            foreach (var userStudyGroup in studyGroups)
            {
                
                userStudyGroup.StudyGroupsId = null;
                _bll.UserStudyGroupsService.Update(userStudyGroup);
            }
            
            var userStudyGroups = await _bll.UserStudyGroupsService.RemoveAsync(id);
            if (userStudyGroups == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
