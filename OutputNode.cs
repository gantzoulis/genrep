using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OutputNode : BaseNode
{
    private string result = "";

    private BaseDialogueNode dialogueNode;
    private Rect dialogueNodeRect;

    public OutputNode()
    {
        windowTitle = "output node";
        hasInputs = true;
    }

    public override void DrawWindow()
    {
        base.DrawWindow();

        Event e = Event.current;
        string input1Title = "None";
        if (dialogueNode)
        {
            input1Title = dialogueNode.getResult();
        }

        GUILayout.Label("Input 1: " + input1Title);

        if (e.type == EventType.Repaint)
        {
            dialogueNodeRect = GUILayoutUtility.GetLastRect();
        }

        GUILayout.Label("Result: " + result);
    }

    public override void DrawCurves()
    {
        if (dialogueNode)
        {
            Rect rect = windowRect;
            rect.x += dialogueNodeRect.x;
            rect.y += dialogueNodeRect.y + dialogueNodeRect.height / 2;
            rect.width = 1;
            rect.height = 1;

           NodeEditor.DrawNodeCurve(dialogueNode.windowRect, rect);
        }
    }

    public override void NodeDeleted(BaseNode node)
    {
        if (node.Equals(dialogueNode))
        {
            dialogueNode = null;
        }
    }

    public override BaseDialogueNode ClickedOnInput(Vector2 pos)
    {
        BaseDialogueNode retVal = null;
        pos.x -= windowRect.x;
        pos.y -= windowRect.y;

        if (dialogueNodeRect.Contains(pos))
        {
            retVal = dialogueNode;
            dialogueNode = null;
        }

        return retVal;
    }

    public override void SetInput(BaseDialogueNode input, Vector2 clickPos)
    {
        clickPos.x -= windowRect.x;
        clickPos.y -= windowRect.y;

        if (dialogueNodeRect.Contains(clickPos))
        {
            dialogueNode = input;
        }
    }
}
