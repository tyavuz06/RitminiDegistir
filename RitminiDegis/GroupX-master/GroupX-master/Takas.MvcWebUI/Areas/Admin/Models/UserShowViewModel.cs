using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Takas.Common.Entities.Concrete;

namespace Takas.MvcWebUI.Areas.Admin.Models
{
    public class UserShowViewModel
    {
        public List<User> Users { get; set; }
    }
}