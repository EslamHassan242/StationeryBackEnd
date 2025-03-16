using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stationery.CORE.DTOS.SuppliersDtos;
using Stationery.EF;

namespace Stationery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SuppliersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetSuppliers")]
        public async Task<ActionResult<IEnumerable<SuppliersResponseDto>>> GetSuppliers()
        {
            var suppliers = await _unitOfWork.Suppliers.GetAllAsync();
            if (suppliers == null)
            {
                return NotFound();
            }
            var suppliersResponseDto = _mapper.Map<IEnumerable<SuppliersResponseDto>>(suppliers);
            return Ok(suppliersResponseDto);

        }

        [HttpGet("GetSupplierById/{id}")]
        public async Task<ActionResult<SuppliersResponseDto>> GetSupplierById(int id)
        {
            var suppliers = await _unitOfWork.Suppliers.GetByIdAsync(id);
            if (suppliers == null)
            {
                return NotFound();
            }
            var suppliersResponseDto = _mapper.Map<SuppliersResponseDto>(suppliers);
            return Ok(suppliersResponseDto);

        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] InsertSupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Suppliers>(supplierDto);

            if (supplier == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }
            try
            {
                await _unitOfWork.Suppliers.AddAsync(supplier);
                _unitOfWork.Complete();
                return Ok(new { message = "Supplier Added successfully", supplierId = supplier.ID });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }



        [HttpPut("UpdateExistingSupplier/{id}")]
        public async Task<IActionResult> UpdateExistingSupplier(int id, [FromBody] InsertSupplierDto supplierDto)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
            if (supplier == null)
                return NotFound(new { message = "Supplier not found" });

            try
            {
                _mapper.Map(supplierDto, supplier);
                _unitOfWork.Complete();
                return Ok(new { message = "Supplier  Updated successfully", supplierId = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [HttpDelete("DeleteSupplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound(new { message = "Supplier not found" });
            }
          
            try
            {
                _unitOfWork.Suppliers.Delete(supplier);
                _unitOfWork.Complete();
                return Ok(new { message = "Supplier  deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


    }
}
