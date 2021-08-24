using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird_Result : MonoBehaviour
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

        GUI.TextField(new Rect(525, 200, 50, 25), str, 10);

        if (GUI.Button(new Rect(500, 300, 100, 30), "Restart"))
        {
            Debug.Log("Restart");

            SceneManager.LoadScene("FlappyBird");
        }

        if (GUI.Button(new Rect(500, 400, 100, 30), "Exit"))
        {
            Debug.Log("Exit");

            Application.Quit();
        }

    }
}
