using BitirmeCalismasiAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeCalismasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly BitirmeContext _context;
        public HastaController(BitirmeContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public List<Hasta> Hastalar()
        {
            var hastas =  _context.Hastas.ToList();
            hastas.ForEach(x =>
            {
                x.HastaPersonel = _context.Personels.FirstOrDefault(y => y.PersonelID == x.PersonelID);
                x.HastaBileklik = _context.Bilekliks.FirstOrDefault(z => z.BileklikID == x.BileklikID);

            });
            //var innerJoin = from h in hastas
            //                join p in await _context.Personels.ToListAsync()
            //                on h.PersonelID equals p.PersonelID
            //                select (h,p);



            if (hastas.Count !=0)
                return hastas;


            return null;
        }
    }
}
