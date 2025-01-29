
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Stationery.CORE.DTOS.OrderDetailsDtos;
using System.Linq.Expressions;

namespace Stationery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetailsResponseDto>>> GetOrderDetails(decimal orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
                return NotFound($"No Order found with Id {orderId}");

            Expression<Func<OrdersDetails, bool>> criteria = x => x.OrderId == orderId;
            var orderDetails= await _unitOfWork.OrderDetails.FindAllAsync(criteria);
            return Ok(orderDetails.ToList());

        }


        [HttpPost("AddOrderDetails")]
        public async Task<IActionResult>AddOrderDetails([FromForm]BasicOrderDetailsDto orderDetailsDto)
        {
            var orderDetails = _mapper.Map<OrdersDetails>(orderDetailsDto);
            var order =await _unitOfWork.Orders.GetByIdAsync(orderDetailsDto.OrderId);
            if(order==null)
            {
                return BadRequest(new { message = $"there are no order with id {orderDetails.OrderId}" });
            }
            if (!_unitOfWork.ProductUnits.FindIfQuentityIsExist(orderDetailsDto.ProductID, orderDetailsDto.UnitId, orderDetailsDto.Quentity))
            {
                return BadRequest(new { message = "there are no available quentity of this item " });
            }

            if (orderDetails == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }
            try
            {
                await _unitOfWork.OrderDetails.AddAsync(orderDetails);
                _unitOfWork.Complete();
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }



        }


    }
}
