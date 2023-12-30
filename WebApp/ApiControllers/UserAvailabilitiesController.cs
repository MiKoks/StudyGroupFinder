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
    /// Controller for managing user availabilities.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserAvailabilitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserAvailabilitiesMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAvailabilitiesController"/> class.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoMapper"></param>
        /// <param name="uow"></param>
        /// <param name="bll"></param>
        public UserAvailabilitiesController(ApplicationDbContext context, IMapper autoMapper, IAppUOW uow, IAppBLL bll)
        {
            _context = context;
            _mapper = new UserAvailabilitiesMapper(autoMapper);
            _bll = bll;
        }

        // GET: api/UserAvailabilities
        /// <summary>
        /// Retrieves a list of user availabilities.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAvailabilitiesDTO>>> GetUserAvailabilities()
        {
            var data = await _bll.UserAvailabilitiesService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/UserAvailabilities/5
        /// <summary>
        /// Retrieves details of a specific user availability.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAvailabilitiesDTO>> GetUserAvailabilities(Guid id)
        {
            var userAvailabilities = await _bll.UserAvailabilitiesService.FindAsync(id);

            if (userAvailabilities == null)
            {
                return NotFound();
            }

            return _mapper.Map(userAvailabilities)!;
        }

        // PUT: api/UserAvailabilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a user availability.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userAvailabilities"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAvailabilities(Guid id, UserAvailabilitiesDTO userAvailabilities)
        {
            if (id != userAvailabilities.Id)
            {
                return BadRequest();
            }

            var bllUserAvailabilities = _mapper.Map(userAvailabilities);
            _bll.UserAvailabilitiesService.Update(bllUserAvailabilities!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/UserAvailabilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new user availability.
        /// </summary>
        /// <param name="userAvailabilities"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<UserAvailabilitiesDTO>> PostUserAvailabilities(UserAvailabilitiesDTO userAvailabilities)
        {
            var bllUserAvailabilities = _mapper.Map(userAvailabilities);
            _bll.UserAvailabilitiesService.Add(bllUserAvailabilities!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetUserAvailabilities", new { id = userAvailabilities.Id }, userAvailabilities);
        }

        // DELETE: api/UserAvailabilities/5
        /// <summary>
        /// Deletes a user availability.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAvailabilities(Guid id)
        {
            var userAvailabilities = await _bll.UserAvailabilitiesService.RemoveAsync(id);
            if (userAvailabilities == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
