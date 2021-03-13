using BusinessLogic.UserManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirWebApiTask.UserController
{
    public class UserController : Controller
    {
        private readonly IUserCRUDService userService;
        private readonly IServiceResultStatusToResponseConverter responseConverter;

        public IActionResult Index()
        {
            return View();
        }
    }
}
