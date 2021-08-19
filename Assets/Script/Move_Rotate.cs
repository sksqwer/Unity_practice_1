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

        float ret = Vector3.Angle(tar.transform.forward, this.transform.up);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rotation += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rotation -= 0.1f;
        }
        else
            rotation = 0;
        

        if (rotation >= 45)
            rotation = 45.0f;
        else if (rotation <= -45)
            rotation = -45.0f;
        


    }

    void rotate()
    {
        float deltarot = rotation;

        GameObject tar = GameObject.Find("Car");
        //        Vector3 carpos = tar.transform.eulerAngles;
        //Vector3 carpos = new Vector3(0,90,90);
        //       Vector3 tirepos = this.transform.eulerAngles;
        float ret = Vector3.Angle(tar.transform.forward, this.transform.up);
        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        //       Debug.Log("angle : " + ret);
        //       Debug.Log("rotation : " + rotation);

        //if (ret >= -45 && ret <= 45)
        //{
        //    float speed = Move.moveSpeed;

        //    if (rotation != 0)
        //        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        //    //           this.transform.rotation *= Quaternion.AngleAxis(speed, Vector3.down);

        //    ret = Vector3.Angle(tar.transform.forward, this.transform.up);
        //    if (ret < -45 || ret > 45)
        //    {
        //        transform.localRotation = Quaternion.AngleAxis(rotation, Vector3.back);
        //    }
        //}
    }
}
