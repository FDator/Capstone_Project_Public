using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Commands
{
    public class SelectRecipeFileCommand : CommandBase
    {
        ViewModelClass _vm;

        public SelectRecipeFileCommand(ViewModelClass vm)
        {
            _vm = vm;
        }

        public override void Execute(object parameter)
        {
            
            string filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            _vm.getFile(filter);
        }
    }
}
