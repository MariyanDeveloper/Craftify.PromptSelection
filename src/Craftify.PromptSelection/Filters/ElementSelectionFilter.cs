using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace Craftify.PromptSelection.Filters
{
    public class ElementSelectionFilter : ISelectionFilter
    {
        private readonly Func<Element, bool> _validateElement;
        private readonly Func<Reference, bool> _validateReference;

        public ElementSelectionFilter(
            Func<Element, bool> validateElement)
        {
            _validateElement = validateElement ?? throw new ArgumentNullException(nameof(validateElement));
        }
        public ElementSelectionFilter(Func<Element, bool> validateElement,
            Func<Reference, bool> validateReference)
            : this(validateElement)
        {
            _validateReference = validateReference ?? throw new ArgumentNullException(nameof(validateReference));
        }
        public bool AllowElement(Element element)
        {
            return _validateElement(element);
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return _validateReference is null ||
                   _validateReference.Invoke(reference);
        }
    }
}