using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileConverter;
using ViewModel;


namespace ViewModel.Commands
{
    public class SelectImportCommand : CommandBase
    {

        ViewModelClass _vm;
        public SelectImportCommand(ViewModelClass vm)
        {
            _vm = vm;
        }
        
        public override void Execute(object parameter)
        {
            //_vm.selectFile();            
            string filter = "asy files (*.asy)|*.asy|All files (*.*)|*.*";
            _vm.getFile(filter);
        }
    }
}
