using BusinessLogic;
using BusinessLogic.ShavermaManagement;
using Microsoft.AspNetCore.Mvc;

namespace SimbirWebApiTask.ShavermaController
{
    [Route("shavermas")]
    [ApiController]
    public class ShavermaController : Controller
    {
        private readonly IShavermaCRUDService shavermaService;
        private readonly IServiceResultStatusToResponseConverter responseConverter;
        private readonly IMapper mapper;

        public ShavermaController(IShavermaCRUDService shavermaService, IServiceResultStatusToResponseConverter responseConverter, IMapper mapper)
        {
            this.shavermaService = shavermaService;
            this.responseConverter = responseConverter;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return responseConverter.GetResponse(shavermaService.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return responseConverter.GetResponse(shavermaService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(ShavermaViewCreateModel shaverma)
        {
            return responseConverter.GetResponse(shavermaService.Create(mapper.Map<ShavermaViewCreateModel, ShavermaCreateModel>(shaverma)), Request.Path.Value);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Update(int id, ShavermaViewUpdateModel shaverma)
        {
            return responseConverter.GetResponse(shavermaService.Update(id, mapper.Map<ShavermaViewUpdateModel, ShavermaServiceModel>(shaverma)));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return responseConverter.GetResponse(shavermaService.Delete(id));
        }
    }
}
