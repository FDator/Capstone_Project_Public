using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;
using FileConverter;

namespace ViewModel
{
    public class ViewModelClass : ViewModelBase
    {
        #region PROPERTIES
        //Commands
        public ICommand SelectImportCommand { get; }
        public ICommand SelectRecipeFileCommand { get; }
        public ICommand ConvertFileCommand { get; }
        //Properties
        private string _importPath;
        public string importPath
        {
            get
            {
                return _importPath;
            }
            set
            {
                _importPath = value;
                OnPropertyChanged(nameof(importPath));
            }
        }

        private string _recipePath;
        public string recipePath
        {
            get
            {
                return _recipePath;
            }
            set
            {
                _recipePath = value;
                OnPropertyChanged(nameof(recipePath));
            }
        }

        private string _conversionProgress;
        public string conversionProgress
        {
            get
            {
                return _conversionProgress;
            }
            set
            {
                _conversionProgress = value;
                OnPropertyChanged(nameof(conversionProgress));
            }
        }

        private string _outputFileName = "output";
        public string outputFileName
        {
            get
            {
                return _outputFileName;
            }
            set
            {
                _outputFileName = value;
                OnPropertyChanged(nameof(outputFileName));
            }
        }

        #endregion

        #region FUNCTIONS
        public ViewModelClass()
        {
            SelectImportCommand = new SelectImportCommand(this);
            ConvertFileCommand = new ConvertFileCommand(this);
            SelectRecipeFileCommand = new SelectRecipeFileCommand(this);
        }

        public void getFile(string filter)
        {
            
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                setFile(openFileDialog.FileName, Path.GetExtension(openFileDialog.FileName));
                return;
            }
            return;
        }

        public void getOutputFolder()
        {
            //Check if files are ready for conversion  
            if (!checkConversionReady())
            {
                return;
            }
            //Declare Variables to start conversion progress            
            var fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {                
                //MessageBox.Show(fbd.SelectedPath);
                convertFile(fbd.SelectedPath);
            }
            return;
        }

        //Take the imported file, recipe file, and output file name to start conversion progress
        public void convertFile(string outputFilePath)
        {
            //Declare Variables to start conversion progress
            FileImporterExporter converter = new FileImporterExporter();                        
            conversionProgress = "Converting File...";
            bool status = converter.extractData(importPath, recipePath, outputFilePath, outputFileName);
            if (status == true)
            {                    
                conversionProgress = "Conversion Done!";
            }                
            else
            {             
                conversionProgress = "Error with converting the file";                
            }                                        
            return;            
        }
        public void changeStatusMessage()
        {
            conversionProgress = conversionStatus();
        }

        //Checks if import path and recipe path are filled in
        public string conversionStatus()
        {
            if (importPath != null && recipePath != null)
                return "Ready to convert!";

            return "Please select all files necessary for conversion";
        }

        public void setFile(string filePath, string fileExt) 
        {
            switch (fileExt)
            {
                case ".ASY":
                case ".asy":
                    importPath = filePath;
                    break;
                case ".xml":
                    recipePath = filePath;
                    break;
                default: return; //FileNotSupported                      
            }
            changeStatusMessage();
        }

        public bool checkConversionReady()
        {
            if (conversionStatus() == "Ready to convert!")
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
