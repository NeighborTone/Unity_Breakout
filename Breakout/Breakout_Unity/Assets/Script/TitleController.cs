using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {
    public GUIStyle gui_Start;
    float r, g, b;
    
    void Start()
    {
        r = 50;
        g = 20;
        b = 40;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Breakout");
        }
       r += Random.Range(0f, 2f);
       g += Random.Range(0f, 2f);
       b += Random.Range(0f, 2f);
        if(r >= Random.Range(180f, 255f) || g >= Random.Range(180f, 255f) || b >= Random.Range(180f, 255f))
        {
            Start();
        }
    }

    void OnGUI()
    {
        gui_Start.normal.textColor = new Color(r / 255f, g / 255f, b / 255f);
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Press to \"Z\" key", gui_Start);
       
    }
}
