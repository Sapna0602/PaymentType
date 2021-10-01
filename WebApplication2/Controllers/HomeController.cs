using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaymentTypes.Constants;
using PaymentTypes.Enums;
using PaymentTypes.IServices;
//using PaymentTypes.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IAgentCommission _agentCommission;
        private readonly IPacking _packing;
        public HomeController(IEmailService emailService, IAgentCommission agentCommission, IPacking packing)
        {
            _emailService = emailService;
            _agentCommission = agentCommission;
            _packing = packing;
        }
        public IActionResult Index()
        {
            var list = new List<SelectListItem>() {
        new SelectListItem  { Text = "Select payment type", Value = "0" },
        new SelectListItem  { Text = "PhysicalProduct", Value = "1" },
        new SelectListItem  { Text = "Book", Value = "2" },
        new SelectListItem  { Text = "ActivateMembership", Value = "3" },
        new SelectListItem  { Text = "UpgradeMembership", Value = "4" },
        new SelectListItem  { Text = "VideoLearning", Value = "5" },
        };
            ViewBag.PaymentType = list;

            return View();
        }

        [HttpPost]
        public IActionResult About(IFormCollection form)
        {
            PaymentType paymentType = (PaymentType)Enum.Parse(typeof(PaymentType), form["paymentType"], true);
            PaymentAnalysis(paymentType);
            ViewData["Message"] = PaymentAnalysis(paymentType);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        private string PaymentAnalysis(PaymentType type)
        {
            switch(type)
            {
                case PaymentType.ActivateMembership:ActivateMembership();
                    return "Activated Membership";
                case PaymentType.Booking:GenerateDuplicatePackingSlip();
                    return "Duplicated packaging slip generated";
                case PaymentType.PhysicalProduct:GeneratePackingSlip();
                    return "Packaging slip generated";
                case PaymentType.UpgradeMembership:UpgradeMembership();
                    return "Upgraded membership";
                case PaymentType.VideoLearning:VideLearningUpdate("Learning to Sk");
                    return "Enrolled for learning video";
                default:
                    return string.Empty;
            }
        }

        private void GeneratePackingSlip()
        {
            // Code for generating package slip coading
            _packing.GeneratePackingSlip(false, false);
            // generate agent commission
           bool result=_agentCommission.GenerateCommission();
        }
        private void GenerateDuplicatePackingSlip()
        {
            // code for generating duplicate packing slip coading
            _packing.GeneratePackingSlip(true, false);
            bool result = _agentCommission.GenerateCommission();
        }
        private void ActivateMembership()
        {
            // activate membership coading
            //sending a mail
            SendMail("to@gmail.com", "Activation", "Activation Successful");
        }
        private void UpgradeMembership()
        {
            // Upgrading membership coading
            SendMail("to@gmail.com", "Upgrade", "Upgrade Successful");
        }

        private void VideLearningUpdate(string videoType)
        {
            if(videoType.Equals(LearningVideoTypes.Learning_to_Ski))
                _packing.GeneratePackingSlip(false, true);
            else
                _packing.GeneratePackingSlip(false, false);
        }
        private void SendMail(string to,string subject,string message)
        {
            MailAddress from = new MailAddress("sender@gmail.com", "Sender");
            MailAddress To = new MailAddress(to);
            MailMessage Message = new MailMessage(from, To);
            Message.Subject = subject;
            Message.Body = message;
            _emailService.SendEmail(Message);
        }
    }
}
