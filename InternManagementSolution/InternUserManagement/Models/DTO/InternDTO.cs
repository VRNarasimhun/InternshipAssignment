using InternUserManagement.Models;

namespace InterUserManagementAPI.Models.DTOs
{
    public class InternDTO : Intern
    {
        public string? PasswordClear { get; set; }
    }
}