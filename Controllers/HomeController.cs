using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using LoginReg.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private LoginRegContext dbContext;
        public HomeController(LoginRegContext context)
        {
            dbContext = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            
            if(dbContext.Users.Any(u=>u.Email == newUser.Email))
            {
            ModelState.AddModelError("Email", "That Email already exists!");
            
            }

            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                HttpContext.Session.SetInt32("ID", newUser.Id);
                dbContext.Add(newUser);
                dbContext.SaveChanges();

                return RedirectToAction("Success");
            }
            return View("Index");
        }
        [HttpGet("Success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("Login")]
        public IActionResult LogView()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(Login logUser)
        {
            if(ModelState.IsValid)
            {
                User _logUser = dbContext.Users.FirstOrDefault(i => i.Email == logUser.Email);


                if(_logUser != null)
                {
                    var hasher = new PasswordHasher<Login>();
                    var result = hasher.VerifyHashedPassword(logUser, _logUser.Password, logUser.Password);
                    if(result == 0)
                    {
                        ModelState.AddModelError("Email", "Incorrect Email or Password");
                        return View("LogView");
                    }
                    HttpContext.Session.SetInt32("ID", _logUser.Id);
                    return RedirectToAction("Success");
                }
                ModelState.AddModelError("Email", "That email doesn't exist. Please check spelling or register");
            }
            return View("LogView");
        }
    }   
}
