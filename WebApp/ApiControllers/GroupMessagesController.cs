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
    /// Controller for managing group messages.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GroupMessagesController : ControllerBase
    {
        
        private readonly GroupMessagesMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMessagesController"/> class.
        /// </summary>
        /// <param name="autoMapper"></param>
        /// <param name="uow"></param>
        /// <param name="bll"></param>
        public GroupMessagesController(IMapper autoMapper, IAppUOW uow, IAppBLL bll)
        {
            
            _mapper = new GroupMessagesMapper(autoMapper);
            _bll = bll;
        }

        // GET: api/GroupMessages
        /// <summary>
        /// Retrieves a list of group messages.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupMessagesDTO>>> GetGroupMessages()
        {
            var data = await _bll.GroupMessagesService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/GroupMessages/5
        /// <summary>
        /// Retrieves details of a specific group message.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupMessagesDTO>> GetGroupMessages(Guid id)
        {
            var groupMessages = await _bll.GroupMessagesService.FindAsync(id);

            if (groupMessages == null)
            {
                return NotFound();
            }

            return _mapper.Map(groupMessages)!;
        }

        // PUT: api/GroupMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a group message.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupMessages"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupMessages(Guid id, GroupMessagesDTO groupMessages)
        {
            if (id != groupMessages.Id)
            {
                return BadRequest();
            }

            var bllGroupMessages = _mapper.Map(groupMessages);
            _bll.GroupMessagesService.Update(bllGroupMessages!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/GroupMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new group message.
        /// </summary>
        /// <param name="groupMessages"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GroupMessagesDTO>> PostGroupMessages(GroupMessagesDTO groupMessages)
        {
            var bllGroupMessages = _mapper.Map(groupMessages);
            _bll.GroupMessagesService.Add(bllGroupMessages!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetGroupMessages", new { id = groupMessages.Id }, groupMessages);
        }

        // DELETE: api/GroupMessages/5
        /// <summary>
        /// Deletes a group message.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupMessages(Guid id)
        {
            var groupMessages = await _bll.GroupMessagesService.RemoveAsync(id);
            if (groupMessages == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
