using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;

namespace RevitFamilyParametersManager.Interfaces
{
    public interface ISharedParameterManagerService
    {
        SharedParameterManager GetSharedParameterManager(ExternalCommandData commandData);
    }
}