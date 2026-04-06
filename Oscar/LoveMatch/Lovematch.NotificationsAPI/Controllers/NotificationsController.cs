using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using Lovematch.NotificationsAPI.Models;

namespace Lovematch.NotificationsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        [HttpPost("send")]
        public async Task<IActionResult> Send(NotificationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.DeviceToken))
                return BadRequest("DeviceToken is verplicht.");

            if (string.IsNullOrWhiteSpace(request.Title))
                return BadRequest("Title is verplicht.");

            if (string.IsNullOrWhiteSpace(request.Body))
                return BadRequest("Body is verplicht.");

            var message = new Message
            {
                Token = request.DeviceToken,
                Notification = new Notification
                {
                    Title = request.Title,
                    Body = request.Body
                }
            };

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

                return Ok(new
                {
                    success = true,
                    messageId = response
                });
            }
            catch (FirebaseMessagingException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        [HttpPost("send-match")]
        public async Task<IActionResult> SendMatch([FromBody] MatchNotificationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.DeviceToken))
                return BadRequest("DeviceToken is verplicht.");

            var message = new Message
            {
                Token = request.DeviceToken,
                Notification = new Notification
                {
                    Title = "Nieuwe match!",
                    Body = $"Je hebt een nieuwe match met {request.MatchedUserName}"
                }
            };

            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

                return Ok(new
                {
                    success = true,
                    messageId = response
                });
            }
            catch (FirebaseMessagingException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
    }
}