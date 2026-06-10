using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultiStateButton
{
    private GUIStyle buttonStyle;
    public int size = 30;

    //This is only if we have backgroundColor
    Color backgroundColor;

    //This is only if we have sprite
    Texture2D tex;
    Rect texCoords;

    private Color defaultBackgroundColor;
    
    private int actualState;
    List<(string text, Color color)> listStates;

    public MultiStateButton(Color? backgroundColor, Sprite sprite, ref List<(string text, Color color)> listStates, int state)
    {
        buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.margin = new RectOffset(0, 0, 0, 0);
        buttonStyle.padding = new RectOffset(0, 0, 0, 0);
        buttonStyle.fixedHeight = size;
        buttonStyle.fixedWidth = size;

        if (backgroundColor != null)
        {
            this.backgroundColor = backgroundColor.Value;

            Color baseTextureColor = new Color(0.85f, 0.85f, 0.85f);
            Texture2D backgroundTex = new Texture2D(1, 1);
            backgroundTex.SetPixel(0, 0, baseTextureColor);
            backgroundTex.Apply();
            buttonStyle.normal.background = backgroundTex;
            buttonStyle.hover.background = backgroundTex;
        }

        if (sprite != null)
        {
            tex = sprite.texture;
        }

        defaultBackgroundColor = GUI.backgroundColor;

        this.listStates = listStates;
        this.actualState = state;
    }

    public bool DrawMultiStateButton()
    {
        if (backgroundColor != null)
        {
            GUI.backgroundColor = backgroundColor;
        }

        Rect rect = GUILayoutUtility.GetRect(30, 30);
        bool buttonResult = false;
        if (GUI.Button(rect, GUIContent.none, buttonStyle))
        {
            actualState++;
            if (actualState >= listStates.Count) actualState = 0;
            buttonResult =  true;
        }

        if(tex != null)
        {
            GUI.DrawTexture(rect, tex, ScaleMode.StretchToFill);
        }

        DrawStateIconsWithOutline(rect);
        GUI.backgroundColor = defaultBackgroundColor;
        return buttonResult;
    }

    private void DrawStateIconsWithOutline(Rect rect)
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = 16;

        Color prev = GUI.contentColor;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(rect.x + 1, rect.y + 1, rect.width, rect.height), listStates[actualState].text, style);

        GUI.contentColor = listStates[actualState].color;
        GUI.Label(rect, listStates[actualState].text, style);

        GUI.contentColor = prev;
    }

    public int GetState()
    {
        return actualState;
    }

    public void CleanState()
    {
        actualState = 0;
    }
}
