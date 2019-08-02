using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcNode : BaseDialogueNode
{
    private BaseDialogueNode input1;
    private Rect input1Rect;

    private BaseDialogueNode input2;
    private Rect input2Rect;

    private CalculationType calculationType;
    public enum CalculationType
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public CalcNode()
    {
        windowTitle = "Calculation Node";
        hasInputs = true;
    }
}
