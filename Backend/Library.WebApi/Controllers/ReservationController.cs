using Microsoft.AspNetCore.Mvc;
using Library.Domain;
using Library.BusinessLogic.Interface;
using Library.SessionLogic.Interface;
using Library.WebApi.Models;
//using Library.WebApi.Filters;
using System;

namespace KiteSurf.WebApi.Controllers
{
  
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private ILogic<Reservation> reserLogic;
        private ISessionLogic<Session> sessionLogic;
        private ILogic<User_Organization> userOrgLogic;
        private ILogic<Book> bookLogic;

        public ReservationController(ILogic<Book> bkLogic,ILogic<Reservation> resLogic,ILogic<User_Organization> usrOrgLogic,ISessionLogic<Session> sesLogic) : base()
        {
            this.reserLogic = resLogic;
            sessionLogic = sesLogic;
            userOrgLogic = usrOrgLogic;
            bookLogic = bkLogic;
        }

        [HttpPost("{id}/{ano}/{mes}/{dia}")]
        public IActionResult Reserve([FromHeader] Guid token,int ano,int mes,int dia,int id) {
            try
            {
                var fecha = new DateTime(ano,mes,dia);
                var user = sessionLogic.isLogued(token);
                var userOrg = userOrgLogic.GetAll();
                for (int i = 0; i < userOrg.Count; i++)
                {
                    var usr = userOrg[i];
                    if(usr.User.Id ==user.Id){
                        var usu = usr.User;
                        var res = new Reservation();
                        //res.Student=usr;
                        res.InitDate=fecha;
                        res.FinalDate=fecha.AddDays(3);
                        res.book=bookLogic.Get(id);
                        usr.Reservation.Add(res);
                        userOrgLogic.Update(usr.Id,usr);
                        return Ok(res);
                    }
                    
                }
                return Ok(userOrg);
                //var isAdmin = sessionsLogic.IsAdmin(token);

                return Ok("new SessionOutModel().SetModel(token,isAdmin)");
                
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            } 
        }

        [HttpGet]
        public IActionResult Reserve([FromHeader] Guid token) {
            try
            {
                var user = sessionLogic.isLogued(token);
                var userOrg = userOrgLogic.GetAll();
                for (int i = 0; i < userOrg.Count; i++)
                {
                    var usr = userOrg[i];
                    if(usr.User.Id ==user.Id){
                        var usu = usr.User;
                        var res = usr.Reservation;
                        for (int ii = 0; ii < res.Count; ii++)
                        {
                            res[ii]=reserLogic.Get( res[ii].Id);
                        }
                        return Ok(res);
                    }
                    
                }
                return Ok(userOrg);
                
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            } 
        }
/*
        [HttpGet("Check")]
        public IActionResult CheckLogin([FromHeader] Guid token) {
            //return Ok(sessionsLogic.isLogued(token));
        }

        [HttpGet("Admin")]
        public IActionResult IsAdmin([FromHeader] Guid token) {
            //return Ok(sessionsLogic.IsAdmin(token));
        }

        [HttpGet]
        public IActionResult get([FromHeader] Guid token) {
           //return Ok("test");
        }
*/
      
    }
}