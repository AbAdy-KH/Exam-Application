using ExamApp.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApp.Application.Contracts.Identity
{
    public interface IUserRepository
    {
        Task<bool> UserExistsAsync(string userId);
        //string? GetCurrentUser();
    }
}
