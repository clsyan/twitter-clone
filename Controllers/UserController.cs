using System;
using System.Collections.Generic;
using twitter_clone.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using twitter_clone.Interfaces;
using BCrypt.Net;

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
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if(await _mainservice.UserExists(user) != null) return BadRequest("User already exists");
            if(user == null) return BadRequest();
            User u = new User() {
                At = user.At,
                Username = user.Username,
                Followers = new List<User>(),
                Following = new List<User>(),
                Email = user.Email,
                Joined = DateTime.Now,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };
            return Ok(await _mainservice.CreateUser(u));
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] User credentials)
        {   
            if(credentials.Password == null) return BadRequest("Password not provided");
            
            var user = await _mainservice.UserExists(credentials);
            if(user == null) return NotFound("User don't exists");
            
            if(!BCrypt.Net.BCrypt.Verify(credentials.Password, user.Password)) return BadRequest("Invalid credentials");

            try{
                await _mainservice.DeleteUser(user);
                return Ok("User deleted");
            }catch{
                return StatusCode(500);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User credentials) {
            if(!await _mainservice.Authenticate(credentials)) return BadRequest();
            return Ok("Logged");
        }

        
        [HttpPut]
        [Route("follow")]
        public async Task<IActionResult> Follow([FromBody] User[] users) {
            
            try {
                return Ok(await _mainservice.Follow(users));
            } catch {
                return BadRequest();
            }
            
            
        }
        [HttpGet]
        [Route("followers")]
        public async Task<IActionResult> Followers([FromBody] User user) {
            
            return Ok(await _mainservice.GetFollowers(user));
            
        }
        [HttpGet]
        [Route("following")]
        public async Task<IActionResult> Following([FromBody] User user) {
            
            return Ok(await _mainservice.GetFollowing(user));
            
        }
    }

}