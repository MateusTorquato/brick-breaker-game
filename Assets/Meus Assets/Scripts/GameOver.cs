using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    private void OnGUI()
    {
        GUI.Box(new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 175, 300, 350), "Game Over");
        if (GUI.Button(new Rect((Screen.width / 2) - 60, (Screen.height / 2) - 20, 120, 40), text: "Menu")){
            Application.LoadLevel(name: "Cena00");
        }
        if (GUI.Button(new Rect((Screen.width / 2) - 60, (Screen.height / 2) + 30, 120, 40), text: "Quit")){
            Application.Quit();
        }
    }
}