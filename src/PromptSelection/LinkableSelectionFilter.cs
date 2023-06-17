using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace PromptSelection
{
    public class LinkableSelectionFilter : ISelectionFilter
    {
        private readonly Document _currentDocument;
        private readonly Func<Element, bool> _validateElement;

        public LinkableSelectionFilter(
            Document currentDocument,
            Func<Element, bool> validateElement)
        {
            _currentDocument = currentDocument ?? throw new ArgumentNullException(nameof(currentDocument));
            _validateElement = validateElement ?? throw new ArgumentNullException(nameof(validateElement));
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            if (!(_currentDocument.GetElement(reference) is RevitLinkInstance linkInstance))
            {
                return _validateElement(_currentDocument.GetElement(reference));
            }
            var element = linkInstance.GetLinkDocument()
                .GetElement(reference.LinkedElementId);
            return _validateElement(element);
        }
    }
}