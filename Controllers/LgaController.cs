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
        public List<LgaModel> Lgas { get; set; }
        public LgaController(LgaContext context)
        {
            using (var db = context)
            {
                var lgas = db.Lgas
                    .ToList();

                Lgas = lgas;
            }
        }

        // GET api/lga
        [HttpGet]
        public ActionResult<IEnumerable<LgaViewModel>> Get(string state)
        {
            // convert state the enum
            States statesEnum;
            Enum.TryParse(state?.ToUpper(), out statesEnum);

            IEnumerable<LgaViewModel> lgas = new List<LgaViewModel>();

            // get all LGAs
            // calculate the difference in SEIFA scores and create viewmodel
            lgas = (from l in Lgas
                where l.SEIFADisadvantage2016 != null && l.SEIFADisadvantage2011 != null
                select new LgaViewModel 
                    { 
                        Place = l.Place, 
                        State = l.State, 
                        SEIFADisadvantage2011 = l.SEIFADisadvantage2011, 
                        SEIFADisadvantage2016 = l.SEIFADisadvantage2016, 
                        Difference = l.SEIFADisadvantage2016-l.SEIFADisadvantage2011 } 
                );

            // filter on state 
            if (!statesEnum.Equals(States.None))
            {                
                lgas = (from l in lgas
                    where l.State.Equals(statesEnum.GetDescription())
                    select l);

            }

            // display only those in the top half of the SEIFA increase range
            lgas = (from l in lgas
                orderby l.Difference
                select l);
            int halfCount = lgas.ToList().Count/2;
            lgas = lgas.Skip(halfCount);
            
            return lgas.ToList();
        }
    }

    public class LgaViewModel
    {
        public string Place { get; set; }
        public string State { get; set; }
        public int? SEIFADisadvantage2011 { get; set; }
        public int? SEIFADisadvantage2016 { get; set; }
        public int? Difference { get; set; }
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
