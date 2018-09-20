using Autodesk.Revit.DB;
using RevitFamilyParametersManager.Interfaces;
using RevitPSVUtils;
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

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {

                _value = value;
                foreach (FamilyType famType in this.FamilyManager.Types)
                {
                    //Устанавливаем текущий тип для изменения
                    if (this.StorageType == StorageType.Double)
                    {
                        using (var t = new Autodesk.Revit.DB.Transaction(Document, "Set parameters to all types"))
                        {
                            t.Start();
                            this.FamilyManager.CurrentType = famType;
                            this.FamilyManager.Set(this.Model, NumberUtils.MillimetersToFeet(NumberUtils.ParseStringToDouble(_value)));
                            t.Commit();
                        }
                    }
                    else if (this.StorageType == StorageType.Integer)
                    {
                        using (var t = new Autodesk.Revit.DB.Transaction(Document, "Set parameters to all types"))
                        {
                            t.Start();
                            this.FamilyManager.CurrentType = famType;
                            this.FamilyManager.Set(this.Model, NumberUtils.ParseStringToInt(_value));
                            t.Commit();
                        }
                    }
                    else if (this.StorageType == StorageType.String)
                    {
                        using (var t = new Autodesk.Revit.DB.Transaction(Document, "Set parameters to all types"))
                        {
                            t.Start();
                            this.FamilyManager.CurrentType = famType;
                            this.FamilyManager.Set(this.Model, _value);
                            t.Commit();
                        }
                    }

                }
            }
        }
        public bool IsInstance { get; set; }
        public bool IsShared { get; }
        public string Formula { get; set; }
        public StorageType StorageType { get; set; }
        public FamilyParameter Model { get; set; }
        public FamilyManager FamilyManager { get; set; }
        public Document Document { get; set; }

        public RevitFamilyParameter(FamilyParameter familyParam, FamilyManager familyManager, Document doc)
        {
            //revitFamParams.Add(new RevitFamilyParameter(familyParam.Definition.Name, familyParam.IsInstance,
            //                                                familyParam.IsShared, familyParam.Formula, familyParam.DisplayUnitType));
            Name = familyParam.Definition.Name;
            IsInstance = familyParam.IsInstance;
            IsShared = familyParam.IsShared;
            Formula = familyParam.Formula;
            StorageType = familyParam.StorageType;
            Model = familyParam;
            FamilyManager = familyManager;
            Document = doc;

        }
    }
}
