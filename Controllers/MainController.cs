using System.Collections.Generic;
using twitter_clone.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using twitter_clone.Interfaces;

namespace twitter_clone.Controllers {
    public class MainController : Controller {
        private readonly IMainService _mainservice;

        public MainController(IMainService service) {
            _mainservice = service;
        }
        
        [Route("/")]

        async public Task<List<User>> GetUsers() {
            return await _mainservice.GetUsers();
        }
    }

}