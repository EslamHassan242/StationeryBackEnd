
namespace Stationery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrdersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetOrders")]
        public async Task<ActionResult<IEnumerable<OrdersResponseDto>>> GetOrders( )
        {
            var Orders = await _unitOfWork.Orders.GetAllAsync();
            if (Orders == null)
            {
                return NotFound();
            }
            var aordersResponseDto = _mapper.Map<IEnumerable<OrdersResponseDto>>(Orders);
            return Ok(aordersResponseDto);

        }

        [HttpPost("AddNewEmptyOrders")]
        public async Task<IActionResult> AddNewEmptyOrders([FromBody] InsertEmptyOrderDto orderDto)     
        {
            var order = _mapper.Map<Orders>(orderDto);

            if (order == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }         
            try
            {
                  await _unitOfWork.Orders.AddAsync(order);              
                _unitOfWork.Complete();
                return Ok(new { message = "Order  Placed successfully",orderId=order.ID});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [HttpPut("UpdateExistingEmptyOrders/{id}")]
        public async Task<IActionResult> UpdateExistingEmptyOrders( decimal id,  [FromForm] UpdateExistingEmptyOrderDto orderDto)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)           
                return NotFound(new { message = "order not found" });
          
            try
            {    
                _mapper.Map(orderDto,order);
                _unitOfWork.Complete();
                return Ok(new { message = "Order  Placed successfully", orderId = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("DeleteEmptyOrders/{id}")]
        public async Task<IActionResult> DeleteEmptyOrders(decimal id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound(new { message = "order not found" });
            }
            if(order.Finished ?? true)
            {
                return BadRequest(new { message = "only empty orders can be deleted" });
            }
           
            try
            {
               
                    _unitOfWork.Orders.Delete(order);
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
