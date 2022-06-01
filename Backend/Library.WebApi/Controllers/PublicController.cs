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
    public class PublicController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private ILogic<Admin> adminLogic;
        private ILogic<User_Organization> userOrgLogic;
        private ILogic<Reservation> resLogic;

        public PublicController(ILogger<AdminController> logger,ILogic<Reservation> rsLogic,ILogic<Organization> OrgLogic, ILogic<Admin> admLogic,ILogic<User_Organization> usrOrgLogic)
        {
            _logger = logger;
            adminLogic = admLogic;
            userOrgLogic = usrOrgLogic;
            resLogic = rsLogic;
        }

        [HttpGet("Reservations")]
        public IActionResult getReservations([FromBody]BookModel model,[FromHeader] Guid token)
        {
            try
            {
                
                 var list = new List<Reservation>();
                var organizations = userOrgLogic.GetAll();
                foreach(var usrorg in organizations){
                    if(usrorg.Organization.APIKey==token){
                        var res = usrorg.Reservation;
                        
                        foreach(var reserv in res){  
                            var resp = resLogic.Get(reserv.Id);
                            
                            if(resp.book.ISBN==model.ToEntity().ISBN){
                                list.Add(resp);
                            }
                        }
                    }
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Health")]
        public IActionResult getHealth()
        {
            try
            {
                var organizations = userOrgLogic.GetAll();
                return Ok("WebApi Ok" +"      " + "BDD OK");
            }
            catch (Exception e)
            {
                return BadRequest("WebApi OK"+ "    " + "BDD ERROR" );
            }
        }

        [HttpGet]
        public IActionResult getTop([FromBody]BookModel model,[FromHeader] Guid token)
        {
            try
            {
                return Ok(token);
                var list = new List<Reservation>();
                var organizations = userOrgLogic.GetAll();
                foreach(var usrorg in organizations){
                    if(usrorg.Organization.APIKey==token){
                        var res = usrorg.Reservation;
                        foreach(var reserv in res){
                        if(reserv.book.ISBN==model.ToEntity().ISBN){
                            list.Add(reserv);
                        }
                }
                    }
                }
                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
   
}
