// Создайте приложение, которое подсчитывает количество воздуховодов в модели.

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_API_2_1
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var ducts = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Cast<Duct>() 
                .ToList();

            TaskDialog.Show("Количество воздуховодов:", ducts.Count.ToString());

            return Result.Succeeded;
        }
    }
}
