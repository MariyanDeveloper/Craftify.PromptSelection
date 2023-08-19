using System;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Craftify.PromptSelection.Collections;
using Craftify.PromptSelection.Filters;
using Craftify.PromptSelection.Interfaces;

namespace Craftify.PromptSelection.Options;

public class CurrentAndLinkedDocumentsSelectionOption : IPromptSelectionOption
{
    public Elements PickElements(UIDocument uiDocument, Func<Element, bool> validateElement, string statusPrompt)
    {
        var currentDocument = uiDocument.Document;
        var references = uiDocument
            .Selection
            .PickObjects(
                ObjectType.PointOnElement,
                new LinkableSelectionFilter(currentDocument, validateElement));
        var elements = references
            .Select(r => GetElementByReference(currentDocument, r));
        return new Elements(elements);
    }

    private Element GetElementByReference(Document currentDocument, Reference reference)
    {
        if (currentDocument.GetElement(reference.ElementId) is RevitLinkInstance linkInstance)
        {
            return linkInstance.GetLinkDocument().GetElement(reference.LinkedElementId);
        }
        return currentDocument.GetElement(reference.ElementId);
    }
}