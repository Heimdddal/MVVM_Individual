using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Individual
{
    internal class ViewModel
    {
        public Model model { get; set; }

        public ViewModel()
        {
            model = new Model();
        }
    }
}
