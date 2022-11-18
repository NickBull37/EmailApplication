using EmailApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailApplication.Services
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(EmailRequest emailRequest);
    }
}
