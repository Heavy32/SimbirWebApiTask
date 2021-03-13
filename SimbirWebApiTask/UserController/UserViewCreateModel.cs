using System.ComponentModel.DataAnnotations;

namespace SimbirWebApiTask.UserController
{
    public class UserViewCreateModel
    {
        [Required(ErrorMessage = "Login is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        [EmailAddress]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Must be between 5 and 100 characters", MinimumLength = 5)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
