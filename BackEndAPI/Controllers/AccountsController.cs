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
    public class AccountsController : ControllerBase
    {
        private readonly PTUDContext _context;

        public AccountsController(PTUDContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        [HttpGet("{cusId}")]
        public async Task<IActionResult> GetDetail(int cusId)
        {
            var user = await _context.NguoiDung.FirstOrDefaultAsync(x => x.MaNguoiDung == cusId);
            if (user == null)
                throw new Exception($"Can not find user with Id {cusId}");
            return Ok(user);
        }
    }
   
}
