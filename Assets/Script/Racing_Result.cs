using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Racing_Result : MonoBehaviour
{
    Gamemanager g = Gamemanager.Instance;
    string temp;
    int[] order = new int[4] { -1, -1, -1, -1};
    public Text a;
    // Start is called before the first frame update
    void Start()
    {
        int n = 0;
        for(int i = 0; i < 4; i++)
        {
            if (order[0] == -1)
            {
                order[0] = i;
            }
            else
            {
                n = i;
                for (int j = 0; j < i; j++)
                {
                    if(g.gameScore[order[j]] < g.gameScore[n])
                    {
                        int temp = n;
                        n = order[j];
                        order[j] = temp;
                    }
                }
                order[i] = n;
            }
        }
        temp = "Result\n";
        temp += "1. " + g.playerName[order[0]] + " : " + g.gameScore[order[0]] + "\n";
        temp += "2. " + g.playerName[order[1]] + " : " + g.gameScore[order[1]] + "\n";
        temp += "3. " + g.playerName[order[2]] + " : " + g.gameScore[order[2]] + "\n";
        temp += "4. " + g.playerName[order[3]] + " : " + g.gameScore[order[3]];
        
        print(temp);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(450, 150, 200, 200), temp);


        if (GUI.Button(new Rect(500, 400, 100, 30), "Exit"))
        {
            Debug.Log("Exit");

            Application.Quit();
        }
    }
}
