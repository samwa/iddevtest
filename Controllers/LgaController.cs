using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace iddevtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LgaController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<LgaModel>> Get(string state)
        {
            States statesEnum;
            Enum.TryParse(state?.ToUpper(), out statesEnum);

            var states = new List<LgaModel> 
                { 
                    new LgaModel { Place = "Albury (C)", State = "New South Wales",  SEIFADisadvantage2011=979, SEIFADisadvantage2016=971 },
                    new LgaModel { Place = "Ballina (A)", State = "New South Wales",  SEIFADisadvantage2011=989, SEIFADisadvantage2016=1003 },     
                    new LgaModel { Place = "Alpine (S)", State = "Victoria",  SEIFADisadvantage2011=987, SEIFADisadvantage2016=994 },
                    new LgaModel { Place = "Ararat (RC)", State = "Victoria",  SEIFADisadvantage2011=951, SEIFADisadvantage2016=942 },
                    new LgaModel { Place = "Aurukun (S)", State = "Queensland",  SEIFADisadvantage2011=483, SEIFADisadvantage2016=504 },
                    new LgaModel { Place = "Balonne (S)", State = "Queensland",  SEIFADisadvantage2011=959, SEIFADisadvantage2016=973 },
                    new LgaModel { Place = "Adelaide (C)", State = "South Australia",  SEIFADisadvantage2011=1013, SEIFADisadvantage2016=1014 },
                    new LgaModel { Place = "Adelaide Hills (DC)", State = "South Australia",  SEIFADisadvantage2011=1081, SEIFADisadvantage2016=1080 },
                    new LgaModel { Place = "Albany (C)", State = "Western Australia",  SEIFADisadvantage2011=987, SEIFADisadvantage2016=989 },
                    new LgaModel { Place = "Armadale (C)", State = "Western Australia",  SEIFADisadvantage2011=996, SEIFADisadvantage2016=994 },
                    new LgaModel { Place = "Break O'Day (M)", State = "Tasmania",  SEIFADisadvantage2011=891, SEIFADisadvantage2016=894 },
                    new LgaModel { Place = "Brighton (M)", State = "Tasmania",  SEIFADisadvantage2011=867, SEIFADisadvantage2016=871 },
                    new LgaModel { Place = "Alice Springs (T)", State = "Northern Territory",  SEIFADisadvantage2011=1006, SEIFADisadvantage2016=1007 },
                    new LgaModel { Place = "Barkly (S)", State = "Northern Territory",  SEIFADisadvantage2011=680, SEIFADisadvantage2016=679 },
                    new LgaModel { Place = "Unincorporated ACT", State = "Australian Capital Territory",  SEIFADisadvantage2011=1076, SEIFADisadvantage2016=1075 }
                };

            if (!statesEnum.Equals(States.None))
            {
                states = (from s in states
                    where s.State.Equals(statesEnum.GetDescription())
                    select s).ToList();
            }
            return states;
        }
    }
        
    public enum States
    {
        [Description("None")]
        None = 0,
        [Description("New South Wales")]
        NSW = 1,
        [Description("Victoria")]
        VIC = 2,
        [Description("Queensland")]
        QLD = 4,
        [Description("South Australia")]
        SA = 8,
        [Description("Western Australia")]
        WA = 16,
        [Description("Tasmania")]
        TAS = 32,
        [Description("Northern Territory")]
        NT = 64,
        [Description("Australian Capital Territory")]
        ACT = 128
    }

    public class LgaModel
    {
        public string Place { get; set; }
        public string State { get; set; }
        public int SEIFADisadvantage2011 { get; set; }
        public int SEIFADisadvantage2016 { get; set; }
    }

    public static class EnumExtension
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            string description = null;

            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if(descriptionAttributes.Length > 0)
                        {
                            // we're only getting the first description we find
                            // others will be ignored
                            description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                        }

                        break;
                    }
                }
            }

            return description;
        }
    }
}
