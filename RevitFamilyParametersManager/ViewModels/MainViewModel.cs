using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;
using RevitFamilyParametersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevitFamilyParametersManager.Interfaces;
using System.Collections.ObjectModel;

namespace RevitFamilyParametersManager.ViewModels
{
    public class MainViewModel
    {
        private ISharedParameterManagerService _sharedParameterService;
        private IRevitFamilyParameterService _revitFamilyParameterService;

        public ObservableCollection<RevitFamilyParameter> RevitFamilyParameterList { get; set; }

        public MainViewModel(ISharedParameterManagerService sharedParameterService)
        {
            _sharedParameterService = sharedParameterService;
            _revitFamilyParameterService = new RevitFamilyParameterService();
            RevitFamilyParameterList = new ObservableCollection<RevitFamilyParameter>();
        }

        public void Load(ExternalCommandData commandData)
        {
            var sharedParameterManager = _sharedParameterService.GetSharedParameterManager(commandData);
            RevitFamilyParameterList = _revitFamilyParameterService.GetParameters(commandData);
        }
    }
}
