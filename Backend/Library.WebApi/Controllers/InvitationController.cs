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
using Library.SessionLogic.Interface;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationController : ControllerBase
    {
        private readonly ILogger<InvitationController> _logger;
        private ILogic<Invitation> invitationLogic;
        private ILogic<Admin> adminLogic;
        private ISessionLogic<Session> sessionLogic;
        private ILogic<User_Organization> userOrgLogic;
        private ILogic<Organization> orgLogic;

        public InvitationController(ILogger<InvitationController> logger, ILogic<Invitation> invLogic,ILogic<Organization> orLogic,ILogic<Admin> admLogic,ILogic<User_Organization> usrOrgLogic,ISessionLogic<Session> sesLogic)
        {
            _logger = logger;
            invitationLogic = invLogic;
            adminLogic = admLogic;
            sessionLogic = sesLogic;
            userOrgLogic = usrOrgLogic;
            orgLogic = orLogic;

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var invitacion = invitationLogic.Get(id);
                if (invitacion == null){
                    return NoContent();
                }
                return Ok(invitacion);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult create([FromBody]UserModel model,int id)
        {
            try
            {
                
                var inv = invitationLogic.Get(id);
                
                var org = inv.Organization;
                
                if(inv.Rol == "Admin"){
                    var admin = new Admin();
                    admin.Name=model.Name;
                    admin.Password=model.Password;
                    admin.Mail=model.Mail;
                    adminLogic.Create(admin);
                    admin.Organization=org;
                    adminLogic.Update(admin.Id,admin);
                    return Ok(admin);
                }else{
                    
                    var userOrg = new User_Organization();
                    userOrg.User = model.ToEntity();
                    userOrg.Organization=org;
                    userOrgLogic.Create(userOrg);
                    return Ok(userOrg);
                }
                return Ok(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
    
        }
        [HttpPost]
        public IActionResult create([FromBody]InvitationModel model,[FromHeader] Guid token)
        {
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var user = sessionLogic.isLogued(token);
                    var admin= adminLogic.Get(user.Id);
                    var org = admin.Organization;
                    var invi = model.ToEntity();
                    invi.Organization = org;
                    var invitation = this.invitationLogic.Create(invi);
                    return Ok(invitation);
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
