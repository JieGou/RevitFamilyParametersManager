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
        string StringValue { get; set; }
        double DoubleValue { get; set; }
        int IntValue { get; set; }
        bool IsInstance { get; set; }
        bool IsShared { get; }
        string Formula { get; set; }
    }
}
