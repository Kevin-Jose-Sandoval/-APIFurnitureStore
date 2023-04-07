using APIFurnitureStore.Context;
using APIFurnitureStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFurnitureStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly FurnitureStoreContext _context;

        public OrderController(FurnitureStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _context.Orders
                    .Include(order => order.OrderDetails)
                    .ToListAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _context.Orders
                    .Include(order => order.OrderDetails)
                    .FirstOrDefaultAsync(order => order.Id == id);

                if (order == null) return NotFound();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderModel newOrder)
        {
            try
            {
                if (newOrder == null) return NotFound();
                if (newOrder.OrderDetails == null) return BadRequest("Order should have at least one details");

                await _context.Orders.AddAsync(newOrder);
                await _context.OrderDetails.AddRangeAsync(newOrder.OrderDetails);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.Id }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderModel actualOrder)
        {
            try
            {
                if (actualOrder == null) return NotFound();
                if (actualOrder.Id <= 0) return NotFound();
                if (actualOrder.OrderDetails == null) return BadRequest("Order should have at least one details");

                var existingOrder = await _context.Orders
                    .Include(order => order.OrderDetails)
                    .FirstOrDefaultAsync(order => order.Id == actualOrder.Id);
                
                if (existingOrder == null || existingOrder.OrderDetails == null) return NotFound();

                // update values of OrderModel
                existingOrder.OrderNumber = actualOrder.OrderNumber;
                existingOrder.OrderDate = actualOrder.OrderDate;
                existingOrder.DeliveryDate = actualOrder.DeliveryDate;
                existingOrder.ClientId = actualOrder.ClientId;
                
                // update values of OrderDetailModel
                _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
                _context.Orders.Update(existingOrder);
                _context.OrderDetails.AddRange(actualOrder.OrderDetails);

                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(OrderModel actualOrder)
        {
            try
            {
                if (actualOrder == null) return NotFound();
                var existingOrder = await _context.Orders
                    .Include(order => order.OrderDetails)
                    .FirstOrDefaultAsync(order => order.Id == actualOrder.Id);

                if (existingOrder == null) return NotFound();

                _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
                _context.Orders.Remove(existingOrder);
                
                await _context.SaveChangesAsync();
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
