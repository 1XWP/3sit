using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour
{
    public GUISkin customSkin;

    void OnGUI()
    {
        int buttonWitdth = 100;
        int buttonHeight = 50;
        float halfScreenW = Screen.width * 0.5f;
        float halfButtonW = buttonWitdth * 0.5f;
        GUI.skin = customSkin;
        if (GUI.Button(new Rect(halfScreenW - halfButtonW, 250, buttonWitdth, buttonHeight), "PLAY"))
        {
            Application.LoadLevel("game");
        }
    }
}
