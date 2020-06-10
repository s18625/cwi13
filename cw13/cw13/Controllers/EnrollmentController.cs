using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw13.DTOs;
using cw13.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw13.Controllers
{
    [Route("api/enroll")]
    [ApiController]
    public class EnrollmentController : ControllerBase

    {
        IdbService _service;
        public EnrollmentController(IdbService service)
        {
            _service = service;
        }


        [HttpPost("{id}")]
        public IActionResult AddZamowienie(EnrollZamowienieRequest enza,int id)
        {
            var res = _service.AddZamowienie(enza, id);
            if (res.StartsWith("Bład")) return BadRequest(res);
            return Ok(res);

        }
    }
}