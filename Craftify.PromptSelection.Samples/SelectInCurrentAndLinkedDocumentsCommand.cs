using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Craftify.PromptSelection.Extensions;

namespace Craftify.PromptSelection.Samples;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class SelectInCurrentAndLinkedDocumentsCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        var uiDocument = commandData.Application.ActiveUIDocument;
        var pickedElements = uiDocument.PromptSelectionInCurrentAndLinkedDocuments(
            e => e is Wall && e is FamilyInstance);
        TaskDialog.Show(
            "Picked Elements",
            string.Join(
                ",",
                pickedElements.Select(e => e.Name)));
        return Result.Succeeded;
    }
}