using DataService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace angular10.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("GetUserData")]
        [Authorize(Policy = "User")]
        public IActionResult GetUserData()
        {
            return Ok("This is an normal user");
        }

        [HttpGet]
        [Route("GetAdminData")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok("This is an Admin user");
        }
        [HttpPost]
        [Route("GetUserByRole")]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUserByRole(GetUserByRoleReq req)
        {
            var lstUser = _db.Users.Where(x => x.UserType.Equals(req.RoleId)).ToList();
            if (lstUser.Count > 0)
                return Ok(lstUser);
            
            return NotFound();
        }
        [HttpPost]
        [Route("UpdateUser")]
        [Authorize(Policy = "Admin")]
        public IActionResult UpdateUser(User model)
        {
            if (ModelState.IsValid)
            {
                _db.Entry<User>(model).State=EntityState.Modified;
                int rs = _db.SaveChanges();
                return Ok(rs.ToString());
            }
            return Content("Lỗi");
        }
    }
}