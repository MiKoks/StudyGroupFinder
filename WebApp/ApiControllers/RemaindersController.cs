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
    /// Controller for managing reminders.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RemaindersController : ControllerBase
    {
        
        private readonly RemaindersMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemaindersController"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="uow"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public RemaindersController(IMapper autoMapper, IAppBLL bll)
        {
            
            _bll = bll;
            _mapper = new RemaindersMapper(autoMapper);
        }

        // GET: api/Remainders
        /// <summary>
        /// Retrieves a list of reminders.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RemaindersDTO>>> GetRemainders()
        {
            var data = await _bll.RemaindersService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();
            
            return res;
        }

        // GET: api/Remainders/5
        /// <summary>
        /// Retrieves details of a specific reminder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RemaindersDTO>> GetRemainders(Guid id)
        {
            var remainders = await _bll.RemaindersService.FindAsync(id);

            if (remainders == null)
            {
                return NotFound();
            }

            return _mapper.Map(remainders)!;
        }

        // PUT: api/Remainders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a reminder.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="remainders"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRemainders(Guid id, RemaindersDTO remainders)
        {
            if (id != remainders.Id)
            {
                return BadRequest();
            }

            var bllRemainders = _mapper.Map(remainders);
            _bll.RemaindersService.Update(bllRemainders!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Remainders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new reminder.
        /// </summary>
        /// <param name="remainders"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<RemaindersDTO>> PostRemainders(RemaindersDTO remainders)
        {
            var bllRemainders = _mapper.Map(remainders);
            _bll.RemaindersService.Add(bllRemainders!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetRemainders", new { id = remainders.Id }, remainders);
        }

        // DELETE: api/Remainders/5
        /// <summary>
        /// Deletes a reminder.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRemainders(Guid id)
        {
            var remainders = await _bll.RemaindersService.RemoveAsync(id);
            if (remainders == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
