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
        GameObject tar = GameObject.Find("Car");
        Vector3 carpos = tar.transform.position;
        Vector3 tirepos = this.transform.position;
        float ret = Vector3.Angle(tirepos, carpos);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rotation += 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotation -= 0.2f;
        }
        else
        {
            if (rotation > 1)
                rotation = -0.2f;
            else if (rotation < 1)
                rotation = 0.2f;
            else
                rotation = 0.0f;
        }

    }

    void rotate()
    {
        float deltarot = rotation;
        transform.rotation *= Quaternion.AngleAxis(deltarot, Vector3.right);

        GameObject tar = GameObject.Find("Car");
        Vector3 carpos = tar.transform.eulerAngles;
        //Vector3 carpos = new Vector3(0,90,90);
        Vector3 tirepos = this.transform.eulerAngles;
        float ret = Vector3.Angle(this.transform.forward, tar.transform.forward);

        print(ret);

        if(ret > 113 || ret < 50)
        {
            transform.rotation *= Quaternion.AngleAxis(deltarot * -1.0f, Vector3.right);
        }
    }
}
