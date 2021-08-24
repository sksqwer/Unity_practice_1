using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Scene : MonoBehaviour
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
        if (GUI.Button(new Rect(500, 400, 100, 30), "Start"))
        {
            Debug.Log("Start");

            SceneManager.LoadScene("Racing_Scene");
        }


    }
}
