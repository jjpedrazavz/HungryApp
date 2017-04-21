using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreService.Models
{
    public partial class MenuBundle
    {
        public MenuBundle()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuBundleId { get; set; }

        public string MenuBundleName { get; set; }

        public string MenuCategory { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}
