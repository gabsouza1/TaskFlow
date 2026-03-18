using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace TaskFlow.Application.DTO.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [DataType(DataType.Text, ErrorMessage = "Invalid name.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your email.")]
        [Email(ErrorMessage = "Invalid Email.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter your password.")]
        [MinLength(6, ErrorMessage = "Password is too short.")]
        [MaxLength(15, ErrorMessage = "Password is too long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
