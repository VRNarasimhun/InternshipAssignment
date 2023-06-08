using InternUserManagement.Models;
using InterUserManagementAPI.Models;

namespace InterUserManagementAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}