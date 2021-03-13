using BusinessLogic;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace SimbirWebApiTask
{
    public class ServiceResultCodeToResponseConverter : IServiceResultStatusToResponseConverter
    {
        public IActionResult GetResponse<T>(ServiceResult<T> result, string modelLocation = null)
            => result.Status switch
            {
                StatusCode.ItemCreated => new CreatedResult(modelLocation + (result.Item as IUniqueModel)?.Id, result.Item),
                StatusCode.ItemUpdated => new NoContentResult(),
                StatusCode.ItemRecieved => new OkObjectResult(result.Item),
                StatusCode.ItemNotFound => new NotFoundObjectResult(result.Item),
                StatusCode.ItemDeleted => new NoContentResult(),
                StatusCode.NoContent => new NoContentResult(),
                StatusCode.ItemAlreadyCreated => new ObjectResult(result.Message) { StatusCode = 422},
                _ => new BadRequestResult(),
            };
    }
}
