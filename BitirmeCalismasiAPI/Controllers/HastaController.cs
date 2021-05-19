using AutoMapper;
using BitirmeCalismasiAPI.Models;
using BitirmeCalismasiAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace BitirmeCalismasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly BitirmeContext _context;
        private readonly IMapper _mapper;
        public HastaController(BitirmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [Route("{hastaID}")]
        [HttpGet]
        public IActionResult GetHastaById(int hastaID)
        {
            var hasta = _context.Hastas.SingleOrDefault(x => x.HastaID == hastaID);
            if (hasta == null) return NotFound("id is wrong");

            var returnValue = _mapper.Map<FullFieldsHastaResponseModel>(hasta);
            returnValue.Bileklik = _mapper.Map<BileklikResponseModel>(_context.Bilekliks
                .SingleOrDefault(x => x.BileklikID == hasta.BileklikID));
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(returnValue);
            return  Ok(jsonString);

        }
    }
}
