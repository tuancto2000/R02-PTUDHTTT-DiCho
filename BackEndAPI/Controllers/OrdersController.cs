using BackEndAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PTUDContext _context;

        public OrdersController(PTUDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = _context.DonHang;
            return Ok(orders);
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetDetail(int orderId)
        {
            var order = await _context.DonHang.Include(x=>x.DSChiTietDonHang).FirstOrDefaultAsync(x=> x.MaDonHang == orderId);
            if (order == null)
                throw new Exception($"Can not find order with Id {orderId}");
            return Ok(order);
        }
    }
}
