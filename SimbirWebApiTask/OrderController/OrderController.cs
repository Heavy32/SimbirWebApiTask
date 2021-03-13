using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.OrderManagement;

namespace SimbirWebApiTask.OrderController
{
    [Route("orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderCRUDService orderService;
        private readonly IServiceResultStatusToResponseConverter responseConverter;
        private readonly IMapper mapper;

        public OrderController(IOrderCRUDService orderService, IServiceResultStatusToResponseConverter responseConverter, IMapper mapper)
        {
            this.orderService = orderService;
            this.responseConverter = responseConverter;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult MakeOrder(OrderViewCreateModel order)
        {
            return responseConverter.GetResponse(orderService.Create(mapper.Map<OrderViewCreateModel, OrderServiceCreateModel>(order)));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return responseConverter.GetResponse(orderService.Get(id));
        }
    }
}
