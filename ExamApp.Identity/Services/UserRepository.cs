using ExamApp.Application.Contracts.Identity;
using ExamApp.Application.Models.Identity;
using ExamApp.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Identity.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            //_httpContextAccessor = httpContextAccessor;
        }

        //public string? GetCurrentUser() =>
            //_httpContextAccessor?.HttpContext?.User?.
            //FindFirstValue(ClaimTypes.NameIdentifier);

        public Task<bool> UserExistsAsync(string userId)
        {
            return _userManager.Users.AnyAsync(u => u.Id == userId);
        }
    }
}
