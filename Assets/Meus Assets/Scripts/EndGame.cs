using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    // Use this for initialization
    private void OnGUI()
    {
        if (GUI.Button(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 50, 120, 40), text: "Menu")){
            Application.LoadLevel(name: "Cena00");
        }
    }
}
