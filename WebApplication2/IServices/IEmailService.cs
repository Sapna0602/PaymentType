using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PaymentTypes.IServices
{
    public interface IEmailService
    {
        bool SendEmail(MailMessage message);
    }
}
