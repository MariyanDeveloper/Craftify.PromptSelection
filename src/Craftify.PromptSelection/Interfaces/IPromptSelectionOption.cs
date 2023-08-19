using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Craftify.PromptSelection.Collections;

namespace Craftify.PromptSelection.Interfaces
{
    public interface IPromptSelectionOption
    {
        Elements PickElements(UIDocument uiDocument, Func<Element, bool> validateElement, string statusPrompt);
    }
}