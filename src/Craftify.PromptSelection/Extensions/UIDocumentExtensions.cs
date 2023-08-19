using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Craftify.PromptSelection.Collections;
using Craftify.PromptSelection.Constants;
using Craftify.PromptSelection.Interfaces;
using Craftify.PromptSelection.Options;

namespace Craftify.PromptSelection.Extensions;

public static class UIDocumentExtensions
{

    public static Elements PromptSelectionInCurrentAndLinkedDocuments(
        this UIDocument uiDocument,
        Func<Element, bool> validateElement,
        string statusPrompt = SelectionPrompts.SelectElements)
    {
        return uiDocument
            .PromptSelectionOfElements(
                validateElement,
                new CurrentAndLinkedDocumentsSelectionOption(),
                statusPrompt);
    }
    
    public static Elements PromptSelectionInCurrentDocument(
        this UIDocument uiDocument,
        Func<Element, bool> validateElement,
        string statusPrompt = SelectionPrompts.SelectElements)
    {
        return uiDocument
            .PromptSelectionOfElements(
                validateElement,
                new CurrentDocumentSelectionOption(),
                statusPrompt);
    }

    public static Elements PromptSelectionInLinkedDocuments(
        this UIDocument uiDocument,
        Func<Element, bool> validateElement,
        string statusPrompt = SelectionPrompts.SelectElements)
    {
        return uiDocument
            .PromptSelectionOfElements(
                validateElement,
                new LinkDocumentSelectionOption(),
                statusPrompt);
    }
    public static Elements PromptSelectionOfElements(
        this UIDocument uiDocument,
        Func<Element, bool> validateElement,
        IPromptSelectionOption promptSelectionOption,
        string statusPrompt = SelectionPrompts.SelectElements)
    {
        return promptSelectionOption
            .PickElements(
                uiDocument,
                validateElement,
                statusPrompt);
    }
}