using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.TextArea(new Rect(200, 50, 100, 30), "Hello World!");
        GUI.TextField(new Rect(400, 50, 100, 30), "Hello World2!");
        GUI.Box(new Rect(600, 50, 100, 30), "Hello World3!");

        GUILayout.Label("Click Button");
        if(GUI.Button(new Rect(800, 50, 100, 30), "¾À ÀüÈ¯"))
        {
            Debug.Log("¾À ÀüÈ¯");
        }

        
    }
}
