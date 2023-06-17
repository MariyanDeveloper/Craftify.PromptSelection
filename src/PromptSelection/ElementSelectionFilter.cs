using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace PromptSelection
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
        public bool AllowElement(Element elem)
        {

            return _validateElement(elem);
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            if (_validateReference == null) return true;
            return _validateReference.Invoke(reference);
        }
    }
}