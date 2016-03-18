using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {
    public GUISkin customSkin;

	void OnGUI ()
    {
    GUI.skin = customSkin;
	if(GUI.Button(new Rect(250,150,100,50), "PLAY"))
        {
            print("click");
        }
	}
}
