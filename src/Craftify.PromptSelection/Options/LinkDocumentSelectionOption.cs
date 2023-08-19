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
    public class LinkDocumentSelectionOption : IPromptSelectionOption
    {
        public Elements PickElements(UIDocument uiDocument,
            Func<Element, bool> validateElement,
            string statusPrompt)
        {
            var document = uiDocument.Document;
            var references = uiDocument.Selection.PickObjects(
                ObjectType.LinkedElement,
                new LinkableSelectionFilter(document, validateElement),
                statusPrompt);
            var selectedElements = references
                .Select(r => (document.GetElement(r.ElementId) as RevitLinkInstance)
                    .GetLinkDocument().GetElement(r.LinkedElementId));
            return new Elements(selectedElements);
        }
    }
}