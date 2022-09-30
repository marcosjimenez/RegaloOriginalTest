using Microsoft.AspNetCore.Mvc;
using RegaloOriginalTest.Services;
using RegaloOriginalTest.ViewModels;

namespace RegaloOriginalTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVentaController : ControllerBase
    {

        private readonly ILogger<ItemVentaController> _logger;
        private readonly IItemVentaService _itemVentaService;

        public ItemVentaController(ILogger<ItemVentaController> logger, IItemVentaService itemVentaService)
        {
            _logger = logger;
            _itemVentaService = itemVentaService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetItemsVenta(int ventaId)
        {
            var data = await _itemVentaService.GetItemsVenta(ventaId);

            if (data.Any())
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{ventaId:int}")]
        public async Task<IActionResult> GetItemVenta(int ventaId, int itemVentaId)
        {
            try
            {
                var data = await _itemVentaService.GetItemVenta(ventaId, itemVentaId);
                return Ok(data);
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message); // Mala práctica, pero hay poco tiempo.
            }
        }

        [HttpPost("{ventaId:int}")]
        public async Task<IActionResult> AddItemVentaAsync(int ventaId, [FromBody] ItemVentaViewModel addItemVenta)
        {

            if (addItemVenta is null)
                throw new ArgumentNullException(nameof(addItemVenta));

            try
            {
                await _itemVentaService.AddItemVentaAsync(ventaId, addItemVenta.ProductoId, addItemVenta.Precio);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); // Mala práctica, pero hay poco tiempo.
            }

            return NoContent();
        }

        [HttpPut("{ventaId:int}")]
        public async Task<IActionResult> UpdateItemVentaAsync(int ventaId, [FromBody] ItemVentaViewModel updateItemVenta)
        {

            if (updateItemVenta is null)
                throw new ArgumentNullException(nameof(updateItemVenta));

            try
            {
                await _itemVentaService.UpdateItemVentaAsync(ventaId, updateItemVenta.Id, updateItemVenta.ProductoId, updateItemVenta.Precio);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Mala práctica, pero hay poco tiempo.
            }

            return NoContent();
        }


        [HttpDelete("{ventaId:int}/{itemVentaId:int}")]
        public async Task<IActionResult> UpdateItemVentaAsync(int ventaId, int itemVentaId)
        {

            try
            {
                await _itemVentaService.DeleteItemVenta(ventaId, itemVentaId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Mala práctica, pero hay poco tiempo.
            }

            return NoContent();
        }

    }
}