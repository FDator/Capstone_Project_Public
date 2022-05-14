using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Commands
{
    public class ConvertFileCommand :CommandBase
    {
        ViewModelClass _vm;
        public ConvertFileCommand(ViewModelClass vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {            
            _vm.getOutputFolder();                     
        }
    }
}
