using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Library.WebApi.Models;
using Library.BusinessLogic.Interface;
using Library.Domain;
using System.Threading.Tasks;
using Library.SessionLogic.Interface;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {

        private readonly ILogger<AdminController> _logger;
        private ILogic<Organization> orgaLogic;
        private ISessionLogic<Session> sessionLogic;
        private ILogic<Admin> adminLogic;

        public OrganizationController(ILogger<AdminController> logger, ILogic<Organization> orgLogic,ISessionLogic<Session> sesLogic,ILogic<Admin> admLogic)
        {
            _logger = logger;
            orgaLogic = orgLogic;
            sessionLogic = sesLogic;
            adminLogic = admLogic;
        }

    

        [HttpPut]
        public IActionResult update([FromHeader]Guid key)
        {
            try
            {
                var orgz = orgaLogic.GetAll();
                
                foreach (var item in orgz)
                {
                    var orga = item;
                    
                    if (orga.APIKey==key)
                    {
                        
                        var organiz2 = item.updateApiKey();
                        var ret = orgaLogic.Update(item.Id,organiz2);
                        return Ok(ret.APIKey);
                    }
                }
                return BadRequest("No existe la organizacion");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult getapikey([FromHeader]Guid token)
        {
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var user = sessionLogic.isLogued(token);
                    var admin= adminLogic.Get(user.Id);
                    var organiz = orgaLogic.Get(admin.Organization.Id);
                    return Ok(organiz.APIKey);

                }else{
                    return BadRequest("El usuario no es Administrador");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
   
}
