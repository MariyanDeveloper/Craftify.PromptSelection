using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PromptSelection;

public static class UIDocumentExtensions
{
    public static List<Element> PickElements(
        this UIDocument uiDocument,
        Func<Element, bool> validateElement,
        IPickElementsOption pickElementsOption,
        string statusPrompt = "")
    {
        return pickElementsOption.PickElements(uiDocument, validateElement, statusPrompt);
    }
}