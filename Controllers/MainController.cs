using System;
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
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AdicinarPost([FromBody] User user)
        {
            Console.WriteLine(user.Email);
            Console.WriteLine(user.At);
            if(await _mainservice.UserExists(user)) return BadRequest("User already exists");
            if(user == null) return BadRequest();
            User u = new User() {
                At = user.At,
                Username = user.Username,
                Followers = null,
                Following = null,
                Email = user.Email,
                Joined = DateTime.Now
            };
            return Ok(await _mainservice.CreateUser(u));
        }
    }

}