using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager.Interfaces
{
    public interface IParameter
    {
        string Name { get; set; }
        string Value { get; set; }
        bool IsInstance { get; set; }
        bool IsShared { get; }
        string Formula { get; set; }
        StorageType StorageType { get; set; }

    }
}
