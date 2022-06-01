using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Library.DataAccess.Interface;
using Library.DataAccess;
using Library.BusinessLogic.Interface;
using Library.BusinessLogic;
using Library.SessionLogic;
using Library.SessionLogic.Interface;
using Library.Domain;

namespace Library.Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, LibraryContext>(); 
        }

        public void AddCustomServices()
        {
            services.AddScoped<IRepository<Admin>,AdminRepository>();    
            services.AddScoped<IRepository<Book>,BookRepository>();    
            services.AddScoped<IRepository<Organization>,OrganizationRepository>();    
            services.AddScoped<IRepository<Reservation>,ReservationRepository>();   
            services.AddScoped<IRepository<Student>,StudentRepository>();    
            services.AddScoped<IRepository<User_Organization>,User_OrganizationRepository>();    
            services.AddScoped<IRepository<User>,UserRepository>();
            services.AddScoped<IRepository<Invitation>,InvitationRepository>();
            services.AddScoped<IRepository<Session>, SessionRepository>();


            services.AddScoped<ILogic<Organization>,OrganizationLogic>();
            services.AddScoped<ILogic<Admin>, AdminLogic>();     
            services.AddScoped<ILogic<Invitation>,InvitationLogic>();       
            services.AddScoped<ILogic<Book>,BookLogic>();   
            services.AddScoped<ILogic<Reservation>,ReservationLogic>();     
            // services.AddScoped<ILogic<Quota>,QuotaLogic>(); 

            services.AddScoped<ILogic<User_Organization>,usrOrgLogic>();     
            services.AddScoped<ILogic<User>,UserLogic>(); 
            // services.AddScoped<ISessionLogic<Session>,SessionLogic.SessionLogic>();
            services.AddScoped<ILogic<User_Organization>,UserOrganizarionLogic>();     
            services.AddScoped<ILogic<Student>,StudentLogic>(); 
            services.AddScoped<ISessionLogic<Session>,SessionLogic.SessionLogic>();
            // services.AddScoped<ILogic<Reservation>,ReservationLogic>();
            // services.AddScoped<ILogic<Schedule>, ScheduleLogic>();
            services.AddScoped<ILogic<User>, UserLogic>();
            // //services.AddScoped<IImportAccommodation, ImportAccommodation>();
                                     
        }
    }
}