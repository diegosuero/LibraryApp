using Microsoft.AspNetCore.Mvc;
using Library.Domain;
using Library.SessionLogic.Interface;
using Library.WebApi.Models;
//using Library.WebApi.Filters;
using System;

namespace KiteSurf.WebApi.Controllers
{
  
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private ISessionLogic<Session> sessionsLogic;

        public SessionsController(ISessionLogic<Session> sessions) : base()
        {
            this.sessionsLogic = sessions;
        }

        [HttpPost]
        public IActionResult Login([FromBody]UserModel model) {
            try
            {
                var token = sessionsLogic.Login(model.ToEntity());
                var isAdmin = sessionsLogic.IsAdmin(token);
                return Ok(new SessionOutModel().SetModel(token,isAdmin));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            } 
        }

        [HttpGet("Check")]
        public IActionResult CheckLogin([FromHeader] Guid token) {
            return Ok(sessionsLogic.isLogued(token));
        }

        [HttpGet("Admin")]
        public IActionResult IsAdmin([FromHeader] Guid token) {
            return Ok(sessionsLogic.IsAdmin(token));
        }

        [HttpGet]
        public IActionResult get([FromHeader] Guid token) {
            return Ok("test");
        }

    }
}