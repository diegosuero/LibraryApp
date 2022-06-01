using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Library.WebApi.Models;
using Library.BusinessLogic.Interface;
using Library.Domain;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private ILogic<Admin> adminLogic;

        public AdminController(ILogger<AdminController> logger, ILogic<Admin> admLogic)
        {
            _logger = logger;
            adminLogic = admLogic;
        }

        [HttpPost]
        public IActionResult Register([FromBody]AdminModel model)
        {
            try
            {
                var admin = this.adminLogic.Create(model.ToEntity());
                return Ok(admin);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
   
}
