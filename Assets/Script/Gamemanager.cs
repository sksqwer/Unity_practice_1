using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    
    private static Gamemanager sInstance;

    public static Gamemanager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("_GameManager");
                sInstance = newGameObj.AddComponent<Gamemanager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);   
    }

    //
    public static int num = 0;
    public static long score = 50000;

    public long[] gameScore = new long[4];
    public float[] gameStartTime = new float[4];
    public float[] gameEndTime = new float[4];
    public string[] playerName = new string[4];


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 4; i++)
        {
            gameEndTime[i] = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0; i < 4; i++)
        {
            if (gameEndTime[i] == 0.0f)
                return;
        }

        SceneManager.LoadScene("Result_Scene");



    }
}
