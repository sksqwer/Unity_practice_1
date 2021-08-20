using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copy_tile : MonoBehaviour
{
    public GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        Copy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Copy()
    {
        for(int i = -10; i < 10; i++)
            for(int j = -10; j < 10; j++)
            {
                Instantiate(Tile, new Vector3(i * 100, 0, j * 100), transform.rotation);
            }
    }
}
