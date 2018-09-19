using RevitFamilyParametersManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitFamilyParametersManager.Models
{
    public class RevitFamilyParameter : IParameter
    {
        public string Name { get; set; }
        public double DoubleValue { get; set; }
        public int IntValue { get; set; }
        public string StringValue { get; set; }
        public bool IsInstance { get; set; }
        public bool IsShared { get; }

        public string Formula { get; set; }

        public RevitFamilyParameter(string name, bool isInstance, bool isShared, string formula)
        {
            Name = name;
            IsInstance = isInstance;
            IsShared = isShared;
            Formula = formula;
        }
    }
}
