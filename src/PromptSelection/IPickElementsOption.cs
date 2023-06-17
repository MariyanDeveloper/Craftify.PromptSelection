using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PromptSelection
{
    public interface IPickElementsOption
    {
        List<Element> PickElements(
            UIDocument uiDocument, Func<Element, bool> validateElement, string statusPrompt);
    }
}