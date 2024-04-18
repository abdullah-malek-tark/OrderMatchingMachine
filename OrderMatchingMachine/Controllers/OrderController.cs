using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderMatchingMachine.Domain;
using OrderMatchingMachine.Dtos;
using OrderMatchingMachine.Services;

namespace OrderMatchingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PlaceOrders([FromBody] List<OrderRequestDto> orderRequestDtos)
        {
            var orders = _mapper.Map<List<Order>>(orderRequestDtos);
            var processedOrder = _orderService.ProcessOrder(orders);

            return Ok(_mapper.Map<List<OrderResponseDto>>(processedOrder));
        }
    }
}
