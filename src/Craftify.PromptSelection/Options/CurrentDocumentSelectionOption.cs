using System;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Craftify.PromptSelection.Collections;
using Craftify.PromptSelection.Filters;
using Craftify.PromptSelection.Interfaces;

namespace Craftify.PromptSelection.Options
{
    public class CurrentDocumentSelectionOption : IPromptSelectionOption
    {
        public Elements PickElements(UIDocument uiDocument,
            Func<Element, bool> validateElement, string statusPrompt)
        {
            var selectedElements = uiDocument
                .Selection
                .PickObjects(
                    ObjectType.Element,
                    new ElementSelectionFilter(validateElement), statusPrompt)
                .Select(r => uiDocument.Document.GetElement(r.ElementId));
            return new Elements(selectedElements);
        }
    }
}