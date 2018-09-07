using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;

namespace RevitFamilyParametersManager.Services
{
    public interface ISharedParameterService
    {
        SharedParameterManager GetSharedParameterManager(ExternalCommandData commandData);
    }
}