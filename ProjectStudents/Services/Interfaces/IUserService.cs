using Cinema.Models.Views;
using Microsoft.AspNetCore.Identity;
using ProjectStudents.Models.Entities;
using ProjectStudents.Models.View;
using System.Security.Claims;

namespace ProjectStudents.Services.Interfaces
{
    public interface IUserService
    {
        public User getUser(string id);

        public bool IsUserLoggedIn(ClaimsPrincipal User);

        // public Task<IdentityResult> Register(RegisterModelView model);

        public Task<SignInResult> Login(LoginModelView model);

        public Task Logout();

       //  public Task<IdentityResult> Register(Teacher teacher);

        public Task<IdentityResult> Register(User student);

        public Task<IdentityResult> Register(RegisterModelView model);

    }
}
