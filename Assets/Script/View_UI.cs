using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_UI : MonoBehaviour
{
    Bird_gameManager g;
    // Start is called before the first frame update
    void Start()
    {
        g = Bird_gameManager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnGUI()
    {
        string str;
        str = g.score.ToString();

        GUI.TextField(new Rect(0, 0, 50, 25), str, 10);


    }
}
