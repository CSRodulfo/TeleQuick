using IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeleQuick.Business;
using TeleQuick.IDataAccess.Core;
using TeleQuick.IService;

namespace TeleQuick.Service
{
    public class AccountManagerService : IAccountManagerService
    {
        IAccountManager _accountManager;
        public AccountManagerService(IAccountManager accountManager)
        {
            _accountManager = accountManager
        }
        public Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return _accountManager.CheckPasswordAsync(user, password);
        }

        public Task<(bool Succeeded, string[] Errors)> CreateRoleAsync(ApplicationRole role, IEnumerable<string> claims)
        {
            return _accountManager.CreateRoleAsync(role, claims);
        }

        public Task<(bool Succeeded, string[] Errors)> CreateUserAsync(ApplicationUser user, IEnumerable<string> roles, string password)
        {
            return _accountManager.CreateUserAsync(user, roles, password);
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(ApplicationRole role)
        {
            return _accountManager.DeleteRoleAsync(role);
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteRoleAsync(string roleName)
        {
            return _accountManager.DeleteRoleAsync(roleName);
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(ApplicationUser user)
        {
            return _accountManager.DeleteUserAsync(user);
        }

        public Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userId)
        {
            return _accountManager.DeleteUserAsync(userId);
        }

        public Task<ApplicationRole> GetRoleByIdAsync(string roleId)
        {
            return _accountManager.GetRoleByIdAsync(roleId);
        }

        public Task<ApplicationRole> GetRoleByNameAsync(string roleName)
        {
            return _accountManager.GetRoleByNameAsync(roleName);
        }

        public Task<ApplicationRole> GetRoleLoadRelatedAsync(string roleName)
        {
            return _accountManager.GetRoleLoadRelatedAsync(roleName);
        }

        public Task<List<ApplicationRole>> GetRolesLoadRelatedAsync(int page, int pageSize)
        {
            return _accountManager.GetRolesLoadRelatedAsync(page, pageSize);
        }

        public Task<(ApplicationUser User, string[] Roles)?> GetUserAndRolesAsync(string userId)
        {
            return _accountManager.GetUserAndRolesAsync(userId);
        }

        public Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return _accountManager.GetUserByEmailAsync(email);
        }

        public Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            return _accountManager.GetUserByIdAsync(userId);
        }

        public Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return _accountManager.GetUserByUserNameAsync(userName);
        }

        public Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return _accountManager.GetUserRolesAsync(user);
        }

        public Task<List<(ApplicationUser User, string[] Roles)>> GetUsersAndRolesAsync(int page, int pageSize)
        {
            return _accountManager.GetUsersAndRolesAsync(page, pageSize);
        }

        public Task<(bool Succeeded, string[] Errors)> ResetPasswordAsync(ApplicationUser user, string newPassword)
        {
            return _accountManager.ResetPasswordAsync(user, newPassword);
        }

        public Task<bool> TestCanDeleteRoleAsync(string roleId)
        {
            return _accountManager.TestCanDeleteRoleAsync(roleId);
        }

        public Task<bool> TestCanDeleteUserAsync(string userId)
        {
            return _accountManager.tes
        }

        public Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            return _accountManager.UpdatePasswordAsync(user, currentPassword, newPassword);
        }

        public Task<(bool Succeeded, string[] Errors)> UpdateRoleAsync(ApplicationRole role, IEnumerable<string> claims)
        {
            return _accountManager.UpdateRoleAsync(role, claims);
        }

        public Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUser user)
        {
            return _accountManager.UpdateUserAsync(user);
        }

        public Task<(bool Succeeded, string[] Errors)> UpdateUserAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            return _accountManager.UpdateUserAsync(user, roles);
        }
    }
}