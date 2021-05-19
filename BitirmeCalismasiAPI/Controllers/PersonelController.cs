using AutoMapper;
using BitirmeCalismasiAPI.Models;
using BitirmeCalismasiAPI.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {

        private readonly BitirmeContext _context;
        private readonly IMapper _mapper;
        public PersonelController(BitirmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("{personelId:int}")]
        [HttpGet]
        public IActionResult  GetPersonelById(int personelId)
        {
            var personel = _context.Personels.FirstOrDefault(x => x.PersonelID == personelId);

            if (personel != null)
            {
                var returnValue = _mapper.Map<PersonelResponseModel>(personel);

                returnValue.Hastas = _context.Hastas.Where(x => x.PersonelID == personel.PersonelID).Select(x => new HastaResponseModel
                {
                    HastaAd = x.HastaAd,
                    HastaID = x.HastaID,
                    HastaSoyad = x.HastaSoyad,
                    HastaYas = x.HastaYas,
                    Bileklik= _context.Bilekliks.Where(a=> a.BileklikID == x.BileklikID).Select(a=> new BileklikResponseModel { BileklikID= a.BileklikID,
                    TakilmaTarihi=a.TakilmaTarihi}).ToList()
                    
                }).ToList();

                return new JsonResult(returnValue);
               // return Ok(returnValue);
            }


           
            return  BadRequest("id is wrong.");
        }

        [HttpGet]
        public IActionResult GetAllPersonel()
        {
            var personel = _context.Personels.ToList();

            if (personel == null) return BadRequest("Personel Listesi Boş");

            var returnValue = new List<PersonelResponseModel>();

            PersonelResponseModel model;
            foreach (var item in personel)
            {
                model = _mapper.Map<PersonelResponseModel>(item);
                model.Hastas =  _mapper.Map<List<HastaResponseModel>>(_context.Hastas.Where(x => x.PersonelID == item.PersonelID).ToList());
                returnValue.Add(model);
            }

            return new JsonResult(returnValue);
            
        }

    }
}
