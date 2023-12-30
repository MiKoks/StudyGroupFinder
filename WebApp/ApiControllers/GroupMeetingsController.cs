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
    /// Controller for managing group meetings.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupMeetingsController : ControllerBase
    {
        
        private readonly GroupMeetingsMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMeetingsController"/> class.
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="uow"></param>
        /// <param name="bll"></param>
        public GroupMeetingsController( IMapper autoMapper, IAppUOW uow, IAppBLL bll)
        {
            
            _mapper = new GroupMeetingsMapper(autoMapper);
            _bll = bll;
        }

        // GET: api/GroupMeetings
        /// <summary>
        /// Retrieves a list of group meetings.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupMeetingsDTO>>> GetGroupMeetings()
        {
            var data = await _bll.GroupMeetingsService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();
            
            return res;
        }

        // GET: api/GroupMeetings/5
        /// <summary>
        /// Retrieves details of a specific group meeting.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupMeetingsDTO>> GetGroupMeetings(Guid id)
        {
          
            var groupMeetings = await _bll.GroupMeetingsService.FindAsync(id);

            if (groupMeetings == null)
            {
                return NotFound();
            }

            return _mapper.Map(groupMeetings)!;
        }

        // PUT: api/GroupMeetings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a group meeting.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupMeetings"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupMeetings(Guid id, GroupMeetingsDTO groupMeetings)
        {
            if (id != groupMeetings.Id)
            {
                return BadRequest();
            }
            
            var bllGroupMeetings = _mapper.Map(groupMeetings);
            _bll.GroupMeetingsService.Update(bllGroupMeetings!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/GroupMeetings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new group meeting.
        /// </summary>
        /// <param name="groupMeetings"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GroupMeetingsDTO>> PostGroupMeetings(GroupMeetingsDTO groupMeetings)
        {
            var bllGroupMeetings = _mapper.Map(groupMeetings);
            _bll.GroupMeetingsService.Add(bllGroupMeetings!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetGroupMeetings", new { id = groupMeetings.Id }, groupMeetings);
        }

        // DELETE: api/GroupMeetings/5
        /// <summary>
        /// Deletes a group meeting.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupMeetings(Guid id)
        {
            var groupMeetings = await _bll.GroupJoinRequestsService.RemoveAsync(id);
            if (groupMeetings == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
