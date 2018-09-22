using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iddevtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LgaController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<LgaModel>> Get()
        {
            return new List<LgaModel> 
                { 
                    new LgaModel { Place = "Albury (C)", State = "New South Wales",  SEIFADisadvantage2011=979, SEIFADisadvantage2016=971 },  
                    new LgaModel { Place = "Ballina (A)", State = "New South Wales",  SEIFADisadvantage2011=989, SEIFADisadvantage2016=1003 }  
                };
        }
    }
}

public class LgaModel
{
    public string Place { get; set; }
    public string State { get; set; }
    public int SEIFADisadvantage2011 { get; set; }
    public int SEIFADisadvantage2016 { get; set; }
}