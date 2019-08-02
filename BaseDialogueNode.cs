using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDialogueNode : BaseNode
{
    public virtual string getResult()
    {
        return "None";
    }

    public override void DrawCurves()
    {
        
    }
}
