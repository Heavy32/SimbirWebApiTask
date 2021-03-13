using BusinessLogic;
using BusinessLogic.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace SimbirWebApiTask.UserController
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCRUDService userService;
        private readonly IServiceResultStatusToResponseConverter responseConverter;
        private readonly IMapper mapper;

        public UserController(IUserCRUDService userService, IServiceResultStatusToResponseConverter responseConverter, IMapper mapper)
        {
            this.userService = userService;
            this.responseConverter = responseConverter;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return responseConverter.GetResponse(userService.Get(id));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return responseConverter.GetResponse(userService.Delete(id));
        }

        [HttpPost]
        public IActionResult Create(UserViewCreateModel user)
        {
            return responseConverter.
                GetResponse(
                    userService.Create(
                        mapper.Map<UserViewCreateModel, UserServiceCreateModel>(user)), Request.Path.Value);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, UserViewUpdateModel user)
        {
            return responseConverter.
                GetResponse(
                userService.Update(
                    id, mapper.Map<UserViewUpdateModel, UserServiceModel>(user)));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return responseConverter.GetResponse(userService.GetAll());
        }
    }
}
