using Autodesk.Revit.DB;
using RevitFamilyParametersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager.Models
{
    public class SharedParameterManager
    {
        public DefinitionFile FilePath { get; set; }
        public DefinitionGroup DefinitionGroup { get; set; }
        public Definitions Definitions { get; set; }
        
    }
}
