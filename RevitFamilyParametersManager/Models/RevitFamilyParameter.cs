using Autodesk.Revit.DB;
using RevitFamilyParametersManager.Interfaces;
using RevitPSVUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using RevitFamilyParametersManager.ViewModels;

namespace RevitFamilyParametersManager.Models
{
    public class RevitFamilyParameter : ViewModelBase, IParameter
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                this.Model.SetParameterName(Document, _name);
                OnPropertyChanged();
            }
        }

        private string _value = string.Empty;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value == value)
                    return;
                _value = value;
                this.Model.SetValue(Document, _value);
                OnPropertyChanged();
            }
        }

        private bool _isInstance = false;
        public bool IsInstance
        {
            get
            {
                return _isInstance;
            }
            set
            {
                if (_isInstance == value)
                    return;
                _isInstance = value;
                this.Model.SwitchTypeOrInstance(Document);
                OnPropertyChanged();
            }
        }
        public bool IsShared { get; }

        private string _formula;
        public string Formula
        {
            get
            {
                return _formula;
            }
            set
            {
                if (_formula == value)
                    return;
                _formula = value;
                this.Model.SetParameterFormula(Document, _formula);
                OnPropertyChanged();
            }
        }
        public StorageType StorageType { get; set; }
        public FamilyParameter Model { get; set; }
        public FamilyManager FamilyManager { get; set; }
        public Document Document { get; set; }

        public RevitFamilyParameter(FamilyParameter familyParam, FamilyManager familyManager, Document doc)
        {
            Document = doc;
            Model = familyParam;
            FamilyManager = familyManager;
            Name = familyParam.Definition.Name;
            IsInstance = familyParam.IsInstance;
            IsShared = familyParam.IsShared;
            Formula = familyParam.Formula;
            StorageType = familyParam.StorageType;
        }
    }
}
