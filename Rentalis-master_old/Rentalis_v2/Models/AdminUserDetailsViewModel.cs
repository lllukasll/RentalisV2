using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rentalis_v2.Models
{
    public class AdminUserDetailsViewModel
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string RoleId { get; set; }
        public List<SelectListItem> RoleList { get; set; }
    }
}