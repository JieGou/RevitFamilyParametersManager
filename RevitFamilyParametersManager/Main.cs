using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;
using RevitFamilyParametersManager.Services;
using RevitFamilyParametersManager.ViewModels;
using RevitFamilyParametersManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        static AddInId appId = new AddInId(new Guid("EA2D5B7A-EF3F-4317-9A32-9604503F11AE"));
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;

            var sharedParameterService = new SharedParameterService();
            var viewModel = new MainViewModel(sharedParameterService);
            var form = new MainView(viewModel);

            form.ShowDialog();
            return Result.Succeeded;
        }
    }
}
