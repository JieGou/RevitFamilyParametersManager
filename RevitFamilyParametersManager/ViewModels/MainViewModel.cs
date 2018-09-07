using RevitFamilyParametersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager.ViewModels
{
    public class MainViewModel
    {
        private ISharedParameterService _sharedParameterService;

        public MainViewModel(ISharedParameterService sharedParameterService)
        {
            _sharedParameterService = sharedParameterService;
        }

        public void Load()
        {
            var sharedParameterManager = _sharedParameterService.GetSharedParameterManager();
        }
    }
}
