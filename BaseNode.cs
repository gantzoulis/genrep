using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class BaseNode : ScriptableObject
{

    #region basic Variables
    public Rect windowRect;
    public bool hasInputs = false;
    public string windowTitle = "";
    #endregion

    public virtual void DrawWindow()
    {
        windowTitle = EditorGUILayout.TextField("Title", windowTitle);
    }

    public abstract void DrawCurves();

    public virtual void SetInput(BaseDialogueNode input, Vector2 clickPos)
    {

    }

    public virtual void NodeDeleted(BaseNode node)
    {

    }

    public virtual BaseDialogueNode ClickedOnInput(Vector2 pos)
    {
        return null;
    }

}
