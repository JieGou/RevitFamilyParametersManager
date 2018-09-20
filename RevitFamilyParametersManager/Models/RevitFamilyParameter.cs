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

namespace RevitFamilyParametersManager.Models
{
    public class RevitFamilyParameter : IParameter
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
                _name = value;

                if (Document == null)
                    return;

                if (this.Model.IsBuiltInParam())
                {
                    return;
                }

                

                if(!this.Model.IsShared)
                {
                    using (var t = new Autodesk.Revit.DB.Transaction(Document, "Set parameters to all types"))
                    {
                        t.Start();
                        this.FamilyManager.RenameParameter(this.Model, _name);
                        t.Commit();
                    }
                }
                
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (Document == null || this.Model.IsReadOnly || !this.Model.UserModifiable)
                    return;
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

        private bool _isInstance = false;
        public bool IsInstance
        {
            get
            {
                return _isInstance;
            }
            set
            {
                if (Document == null)
                    return;
                if (this.Model.IsBuiltInParam())
                    return;

                _isInstance = value;
                using (var t = new Autodesk.Revit.DB.Transaction(Document, "Set parameters to all types"))
                {
                    t.Start();
                    if (IsInstance == true)
                        this.FamilyManager.MakeInstance(this.Model);
                    else
                        this.FamilyManager.MakeType(this.Model);
                    t.Commit();
                }
            }
        }
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
