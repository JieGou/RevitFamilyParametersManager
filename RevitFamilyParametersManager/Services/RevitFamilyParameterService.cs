using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitFamilyParametersManager.Models;
using RevitFamilyParametersManager.Interfaces;
using System.Collections.ObjectModel;

namespace RevitFamilyParametersManager.Services
{
    public class RevitFamilyParameterService : IRevitFamilyParameterService
    {
        public ObservableCollection<RevitFamilyParameter> GetParameters(ExternalCommandData commandData)
        {
            var revitFamParams = new ObservableCollection<RevitFamilyParameter>();

            var familyDoc = commandData.Application.ActiveUIDocument.Document;
            var familyParams = familyDoc.FamilyManager.GetParameters();
            foreach (var familyParam in familyParams)
            {
                revitFamParams.Add(new RevitFamilyParameter(
                                        familyParam, familyDoc.FamilyManager, familyDoc));

            }

            return revitFamParams;
        }
    }
}
