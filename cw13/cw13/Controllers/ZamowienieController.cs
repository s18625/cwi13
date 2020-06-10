using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cw13.Controllers
{
    [Route("api/zamowienie")]
    [ApiController]
    public class ZamowienieController : ControllerBase
    {

        IdbService _service;
        public ZamowienieController(IdbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetZamowienia()
        {
            var res = _service.GetZamowienies();
            return Ok(res);
        }

        [HttpGet("{nazw}")]
        public IActionResult GetZamowienia(string nazw)
        {
            var res = _service.GetZamowienies($"{nazw}");
            if (res==null) return BadRequest("Taki klient nie istnieje");
            if (res.Count()==0) return BadRequest("Ten klient nie skladal zadenego zamowienia");
            return Ok(res);
        }

    }
}