using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stationery.CORE.DTOS.ProductsDtos;
using Stationery.CORE.DTOS.SuppliersDtos;

namespace Stationery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;            
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductsResponseDto>>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            if (products == null)
            {
                return NotFound();
            }
            var productsResponseDto = _mapper.Map<IEnumerable<ProductsResponseDto>>(products);
            return Ok(productsResponseDto);
        }
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductsResponseDto>> GetSupplierById(int id)
        {
            var products = await _unitOfWork.Products.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            var productsResponseDto = _mapper.Map<ProductsResponseDto>(products);
            return Ok(productsResponseDto);

        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] InsertProductsDto productsDto)
        {

            var productExists = await _unitOfWork.Products.Where(p => p.ProductCode == productsDto.ProductCode).AnyAsync();

            if (productExists)
            {
                return BadRequest(new { message = "Product code already exists" });
            }

            var products = _mapper.Map<Products>(productsDto);
            if (products == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }
            

            try
            {
                await _unitOfWork.Products.AddAsync(products);
                _unitOfWork.Complete();
                return Ok(new { message = "Product Added successfully", productId = products.ID });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("UpdateExistingProduct/{id}")]
        public async Task<IActionResult> UpdateExistingProduct(int id, [FromBody] InsertProductsDto productsDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
                return NotFound(new { message = "Product not found" });

            try
            {
                _mapper.Map(productsDto, product);
                _unitOfWork.Complete();
                return Ok(new { message = "Product  Updated successfully", productId = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            try
            {
                _unitOfWork.Products.Delete(product);
                _unitOfWork.Complete();
                return Ok(new { message = "Product  deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

    }
}
