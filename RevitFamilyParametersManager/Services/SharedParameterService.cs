﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevitFamilyParametersManager.Models;
using Autodesk.Revit.UI;

namespace RevitFamilyParametersManager.Services
{
    public class SharedParameterService : ISharedParameterService
    {
        public SharedParameterManager GetSharedParameterManager(ExternalCommandData commandData)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            if (!doc.IsFamilyDocument)
                return null;

            var sharedParameterFilePath = commandData.Application.Application.SharedParametersFilename;

            var sharedParamManager = new SharedParameterManager();

            return sharedParamManager;
        }
    }
}
