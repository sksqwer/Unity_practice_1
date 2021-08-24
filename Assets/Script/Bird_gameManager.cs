using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_gameManager : MonoBehaviour
{

    private static Bird_gameManager sInstance;

    public static Bird_gameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObj = new GameObject("Bird_GameManager");
                sInstance = newGameObj.AddComponent<Bird_gameManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
