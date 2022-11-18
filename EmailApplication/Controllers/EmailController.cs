using EmailApplication.Models;
using EmailApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApplication.Controllers
{
    public class EmailController : ControllerBase
    {
        const int MAX_ATTEMPTS = 3;
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost, Route("SendEmail")]
        public async Task<IActionResult> SendEmailAsync(EmailRequest emailRequest)
        {
            var maxAttempts = MAX_ATTEMPTS;
            var attempts = 1;

            do
            {
                try
                {
                    Log.Information($"SendEmail - Attempt: {attempts}");
                    string messageStatus = await _emailService.SendEmailAsync(emailRequest);
                    Log.Information($"SendEmail - SUCCESS\n");
                    return Ok(messageStatus);
                }
                catch (Exception e)
                {
                    attempts++;
                    Log.Information($"SendEmail - ERROR: {e.Message}\n");
                }
            }
            while (attempts <= maxAttempts);

            
            return BadRequest();           
        }
    }
}
