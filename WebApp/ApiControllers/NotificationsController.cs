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
    /// Controller for managing notifications.
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationsMapper _mapper;
        private readonly IAppBLL _bll;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="uow"></param>
        /// <param name="bll"></param>
        public NotificationsController(IMapper mapper, IAppUOW uow, IAppBLL bll)
        {
            
            _mapper = new NotificationsMapper(mapper);
            _bll = bll;
        }

        // GET: api/Notifications
        /// <summary>
        /// Retrieves a list of notifications.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationsDTO>>> GetNotifications()
        {
            var data = await _bll.NotificationsService.AllAsync();
            
            var res = data
                .Select(e => _mapper.Map(e)!)
                .ToList();
            
            return res;
        }

        // GET: api/Notifications/5
        /// <summary>
        /// Retrieves details of a specific notification.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationsDTO>> GetNotifications(Guid id)
        {
            var notifications = await _bll.NotificationsService.FindAsync(id);

            if (notifications == null)
            {
                return NotFound();
            }

            return _mapper.Map(notifications)!;
        }

        // PUT: api/Notifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a notification.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotifications(Guid id, NotificationsDTO notifications)
        {
            if (id != notifications.Id)
            {
                return BadRequest();
            }

            var bllNotifications = _mapper.Map(notifications);
            _bll.NotificationsService.Update(bllNotifications!);
            await _bll.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Notifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new notification.
        /// </summary>
        /// <param name="notifications"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<NotificationsDTO>> PostNotifications(NotificationsDTO notifications)
        {
            var bllNotifications = _mapper.Map(notifications);
            _bll.NotificationsService.Add(bllNotifications!);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetNotifications", new { id = notifications.Id }, notifications);
        }

        // DELETE: api/Notifications/5
        /// <summary>
        /// Deletes a notification.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifications(Guid id)
        {
            var notifications = await _bll.NotificationsService.RemoveAsync(id);
            if (notifications == null)
            {
                return NotFound();
            }
            await _bll.SaveChangesAsync();

            return NoContent();
        }
    }
}
