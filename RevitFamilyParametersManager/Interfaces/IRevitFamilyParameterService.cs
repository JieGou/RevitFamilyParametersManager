using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager.Interfaces
{
    public interface IRevitFamilyParameterService
    {
        ObservableCollection<RevitFamilyParameter> GetParameters(ExternalCommandData commandData);
    }
}
