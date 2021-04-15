using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFinal.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public List<HomeSlider> HomeSliders { get; set; }
        public List<HomeNews> HomeNews { get; set; }
        public HomeNews HomeNew { get; set; }
    }
}
