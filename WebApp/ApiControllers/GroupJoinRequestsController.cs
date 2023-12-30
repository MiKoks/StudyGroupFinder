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

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Controller for managing group join requests.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupJoinRequestsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly GroupJoinRequestsMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupJoinRequestsController"/> class.
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public GroupJoinRequestsController(IMapper autoMapper, IAppBLL bll)
        {
            
            _bll = bll;
            _mapper = new GroupJoinRequestsMapper(autoMapper);
        }

        // GET: api/GroupJoinRequests
        /// <summary>
        /// Retrieves a list of group join requests.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupJoinRequestsDTO>>> GetGroupJoinRequests()
        {
            var data = await _bll.GroupJoinRequestsService.AllAsync(User.GetUserId());
            
            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();
            
            return res;
        }

        // GET: api/GroupJoinRequests/5
        /// <summary>
        /// Retrieves details of a specific group join request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupJoinRequestsDTO>> GetGroupJoinRequests(Guid id)
        {
            var groupJoinRequests = await _bll.GroupJoinRequestsService.FindAsync(id);

            if (groupJoinRequests == null)
            {
                return NotFound();
            }

            var res = _mapper.Map(groupJoinRequests)!;

            return res;
        }

        // PUT: api/GroupJoinRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a group join request.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupJoinRequests"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupJoinRequests(Guid id, GroupJoinRequestsDTO groupJoinRequests)
        {
            if (id != groupJoinRequests.Id)
            {
                return BadRequest();
            }

            if (!await _bll.GroupJoinRequestsService.IsOwnedByUserAsync(groupJoinRequests.Id, User.GetUserId()))
            {
                return BadRequest("badUser");
            }

            var bllGroupJoinRequests = _mapper.Map(groupJoinRequests);
            _bll.GroupJoinRequestsService.Update(bllGroupJoinRequests!);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/GroupJoinRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new group join request.
        /// </summary>
        /// <param name="groupJoinRequests"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GroupJoinRequestsDTO>> PostGroupJoinRequests(GroupJoinRequestsDTO groupJoinRequests)
        {
            var bllGroupJoinRequests = _mapper.Map(groupJoinRequests);
            _bll.GroupJoinRequestsService.Add(bllGroupJoinRequests!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetGroupJoinRequests", new { id = groupJoinRequests.Id }, groupJoinRequests);
        }

        // DELETE: api/GroupJoinRequests/5
        /// <summary>
        /// Deletes a group join request.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupJoinRequests(Guid id)
        {
            
            var groupJoinRequests = await _bll.GroupJoinRequestsService.RemoveAsync(id);
            if (groupJoinRequests == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
