using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Move_Rotate : MonoBehaviour
{
    public static float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move_rotate();
        rotate();
    }

    void move_rotate()
    {
        GameObject tar = GameObject.Find("Player_Car");

        float ret = Vector3.Angle(tar.transform.forward, this.transform.up);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (rotation >= 0)
                rotation += 0.1f;
            else
                rotation = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (rotation <= 0)
                rotation -= 0.1f;
            else
                rotation = -0.1f;
        }
        else
            rotation = 0.0f;

        if (rotation >= 45)
            rotation = 45.0f;
        else if (rotation <= -45)
            rotation = -45.0f;
        


    }

    void rotate()
    {
        float deltarot = rotation;

        GameObject tar = GameObject.Find("Player_Car");

        float ret = Vector3.Angle(tar.transform.forward, this.transform.up);
        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.back);
    }



}
