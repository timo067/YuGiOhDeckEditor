using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using YuGiOhDeckEditor.Data;

namespace YuGiOhDeckEditor.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>(); // Replace with DB context or data storage

        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = users.Count + 1; // Example: generate an Id
                users.Add(user); // Save user to memory or DB
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Log user in (create session, etc.)
                return RedirectToAction("Index", "Deck");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }
}
