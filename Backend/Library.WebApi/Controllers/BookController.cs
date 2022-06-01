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
using Library.BusinessLogic.Extensions;

namespace Library.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
    

        private readonly ILogger<AdminController> _logger;
        private ILogic<Book> bookLogic;
        private ILogic<Organization> orgaLogic;

        private ISessionLogic<Session> sessionLogic;

        private ILogic<User_Organization> usrOrgLogic;
        private ILogic<Admin> adminLogic;
        private ILogic<User> userLogic;



        public BookController(ILogger<AdminController> logger, ILogic<Book> bkLogic,ILogic<Organization> orgLogic, ILogic<User_Organization> usrOrgLogic, ILogic<User> usrLogic, ILogic<Admin> admLogic,ISessionLogic<Session> sesLogic)
        {
            _logger = logger;
            bookLogic = bkLogic;
            orgaLogic = orgLogic;
            this.usrOrgLogic = usrOrgLogic;
            this.userLogic = usrLogic;
            this.sessionLogic = sesLogic;
            this.adminLogic = admLogic;
        }

        [HttpPost]
        public IActionResult Register([FromBody]BookModel model,[FromHeader] Guid token)
        {
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var user = sessionLogic.isLogued(token);
                    var admin= adminLogic.Get(user.Id);
                 //var book = this.bookLogic.Create(model.ToEntity());
                var organiz = orgaLogic.Get(admin.Organization.Id);
                organiz.Books.Add(model.ToEntity());
                orgaLogic.Update(organiz.Id,organiz);
                return Ok(model.ToEntity());

                }else{
                    return BadRequest("El usuario no es Administrador");
                }
                

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyBook([FromBody] Book book,[FromRoute] int id,[FromHeader] Guid token)
        {
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var user = sessionLogic.isLogued(token);
                    var admin= adminLogic.Get(user.Id);
                    bookLogic.Update(id,book);
                    bookLogic.Update(id,book);
                    return Ok("Se cambio correctamente");
                }else{
                    return BadRequest("El usuario no es Administrador");
                }
                

                
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id,[FromHeader] Guid token)
        {
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var user = sessionLogic.isLogued(token);
                    var book = this.bookLogic.Get(id);
                    bookLogic.Delete(book);
                    return Ok("Se elimino correctamente el libro");
                }else{
                    return BadRequest("El usuario no es Administrador");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
/*
        [HttpGet("User")]
        public IActionResult GetBookByUser([FromHeader] Guid token)
        {
            try
            {
                var user = this.sessionLogic.isLogued(token);
                if (user != null){
                    return Ok(new BookModel().ToModel(this.bookLogic.GetBooksByUser(this.usrOrgLogic,this.orgaLogic,this.userLogic,user)));
                }
                else {
                    return NoContent();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
*/
        [HttpGet]
        public IActionResult GetBooks([FromHeader] Guid token)
        {
            
            try
            {
                var IsAdmin = sessionLogic.IsAdmin(token);   
                if(IsAdmin){
                    var userr = sessionLogic.isLogued(token);
                    var admin= adminLogic.Get(userr.Id);
                    var organiz = orgaLogic.Get(admin.Organization.Id);
                    return Ok(organiz.Books);
                }else{
                    
                    var user = this.sessionLogic.isLogued(token);
                    
                    if (user != null){
                        var useror = usrOrgLogic.GetAll();
                        
                        foreach (var item in useror){
                            //return Ok(item);
                            if (item.User.Id == user.Id){
                                var org = orgaLogic.Get(item.Organization.Id);
                                return Ok(org.Books);
                            }   
                        }
                        return Ok(new BookModel().ToModel(this.bookLogic.GetBooksByUser(this.usrOrgLogic,this.orgaLogic,this.userLogic,user)));
                    }
                    else {
                        return NoContent();
                    }
                }
                

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
   
}
