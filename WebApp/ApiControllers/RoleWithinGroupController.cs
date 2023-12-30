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
    /// Controller for managing roles within a group.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RoleWithinGroupController : ControllerBase
    {
        private readonly RoleWithinGroupMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleWithinGroupController"/> class.
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="autoMapper"></param>
        /// <param name="bll"></param>
        public RoleWithinGroupController( IAppUOW uow, IMapper autoMapper, IAppBLL bll)
        {
            
            _bll = bll;
            _mapper = new RoleWithinGroupMapper(autoMapper);
        }

        // GET: api/RoleWithinGroup
        /// <summary>
        /// Retrieves a list of roles within a group.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleWithinGroupDTO>>> GetRolesWithinGroup()
        {
            var data = await _bll.RoleWithinGroupService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e))
                .ToList();
            
            return Ok(res);
        }

        // GET: api/RoleWithinGroup/5
        /// <summary>
        /// Retrieves details of a specific role within a group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleWithinGroupDTO>> GetRoleWithinGroup(Guid id)
        {
            var roleWithinGroup = await _bll.RoleWithinGroupService.FindAsync(id);

            if (roleWithinGroup == null)
            {
                return NotFound();
            }

            return _mapper.Map(roleWithinGroup)!;
        }

        // PUT: api/RoleWithinGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a role within a group.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleWithinGroup"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoleWithinGroup(Guid id, RoleWithinGroupDTO roleWithinGroup)
        {
            if (id != roleWithinGroup.Id)
            {
                return BadRequest();
            }

            var bllRoleWithinGroup = _mapper.Map(roleWithinGroup);
            _bll.RoleWithinGroupService.Update(bllRoleWithinGroup!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/RoleWithinGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new role within a group.
        /// </summary>
        /// <param name="roleWithinGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<RoleWithinGroupDTO>> PostRoleWithinGroup(RoleWithinGroupDTO roleWithinGroup)
        {
            var bllRoleWithinGroup = _mapper.Map(roleWithinGroup);
            _bll.RoleWithinGroupService.Add(bllRoleWithinGroup!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetRoleWithinGroup", new { id = roleWithinGroup.Id }, roleWithinGroup);
        }

        // DELETE: api/RoleWithinGroup/5
        /// <summary>
        /// Deletes a role within a group.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoleWithinGroup(Guid id)
        {
            var roleWithinGroup = await _bll.RoleWithinGroupService.RemoveAsync(id);
            if (roleWithinGroup == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
