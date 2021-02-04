using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Hrs.Pages
{
    public class IndexModel : PageModel
    {
        public List<Staff> Items { get; set; } 
                
        public void OnGet()
        {            
            Items = new List<Staff> {
                new Staff { StaffId="K01231", Name = "Anton Heryanto Hasan" },
                new Staff { StaffId="K01232", Name = "Aishah Rodzi" },
                new Staff { StaffId="K01233", Name = "Faiq ITCS" },
                new Staff { StaffId="K01234", Name = "Liyana" },
                new Staff { StaffId="K01235", Name = "Muhamad Zul Razak" },
            };
        }
    }
}
