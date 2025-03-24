using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stationery.CORE.DTOS.OrderBuyDtos;

namespace Stationery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersBuyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public OrdersBuyController(IUnitOfWork unitOfWork ,IMapper mapper ) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetOrdersBuy")]
        public async Task<ActionResult<IEnumerable<OrderBuyResponseDto>>> GetOrders()
        {
            var Orders = await _unitOfWork.OrderBuy.GetAllAsync();
            if (Orders == null)
            {
                return NotFound();
            }
            var orderBuyResponseDtos = _mapper.Map<IEnumerable<OrderBuyResponseDto>>(Orders);
            return Ok(orderBuyResponseDtos);
        }
        [HttpPost("AddNewEmptyOrdersBuy")]
        public async Task<IActionResult> AddNewEmptyOrdersBuy([FromBody] InsertEmptyOrderBuyDto orderDto)
        {
            var order = _mapper.Map<OrdersBuy>(orderDto);
            if (order == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }
            try
            {
                await _unitOfWork.OrderBuy.AddAsync(order);
                _unitOfWork.Complete();
                return Ok(new { message = "Order  Placed successfully", orderId = order.ID });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("UpdateExistingEmptyOrdersBuy/{id}")]
        public async Task<IActionResult> UpdateExistingEmptyOrdersBuy(decimal id, [FromForm] UpdateExistingEmptyOrderBuyDto orderDto)
        {
            var order = await _unitOfWork.OrderBuy.GetByIdAsync(id);
            if (order == null)
                return NotFound(new { message = "order not found" });

            try
            {
                _mapper.Map(orderDto, order);
                _unitOfWork.Complete();
                return Ok(new { message = "Order  Placed successfully", orderId = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("DeleteEmptyOrdersBuy/{id}")]
        public async Task<IActionResult> DeleteEmptyOrdersBuy(decimal id)
        {
            var order = await _unitOfWork.OrderBuy.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "order not found" });
            }
            if (order.Finished ?? true)
            {
                return BadRequest(new { message = "only empty orders can be deleted" });
            }
            try
            {
                _unitOfWork.OrderBuy.Delete(order);
                _unitOfWork.Complete();
                return Ok(new { message = "Order  deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


    }
}
