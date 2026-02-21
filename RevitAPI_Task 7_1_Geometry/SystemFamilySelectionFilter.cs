using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Task_7_1_Geometry
{
    internal class SystemFamilySelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return  elem.Category != null &&
                    elem.Category.CategoryType == CategoryType.Model &&
                    !(elem is FamilyInstance);
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
