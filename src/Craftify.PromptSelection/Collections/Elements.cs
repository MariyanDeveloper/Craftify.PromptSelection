using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace Craftify.PromptSelection.Collections;

public class Elements : List<Element>
{
    public Elements(IEnumerable<Element> elements): base(elements)
    {
        
    }
}