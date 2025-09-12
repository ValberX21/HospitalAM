using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAM.Application.ViewModel
{
    public class SelectItemViewModel
    {
        public int Value { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool Selected { get; set; }
    }
}
