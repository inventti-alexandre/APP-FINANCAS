using Application.IO.Core.Domain.Source.Notifications;
using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using Application.IO.Core.Identity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Application.IO.Api.Controllers
{
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected Guid UserId { get; set; }
        protected IAppNotificationHandler<DomainNotification> Errors;

        protected BaseController(IUser user, IAppNotificationHandler<DomainNotification> errors)
        {
            Errors = errors;

            if (user.IsAuthenticated())
                UserId = user.GetUserId();
        }

        protected new IActionResult Response(object result = null)
        {
            if (!Errors.HasNotification)
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = Errors.Get.Select(s => s.Value)
            });
        }
    }
}
