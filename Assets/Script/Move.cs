using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //   public static int moveSpeed = 0;
    public static float moveSpeed = 0;
    public static float Body_rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0.0f, 3.0f, 0.0f);
       // this.transform.Translate( new Vector3(0.0f, 3.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Move_2();
        moveSpeed = Mathf.Clamp(moveSpeed, -10.0f, 10.0f);
        Debug.Log("moveSpeed : " + moveSpeed);
 //       rotate();
        move();
    }
    
    void Move_1()
    {

        float moveDelta = moveSpeed * Time.deltaTime;
        Vector3 pos = this.transform.position;
        pos.x += moveDelta;
        this.transform.position = pos;
    }
    void Move_2()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveSpeed += 0.2f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveSpeed -= 0.2f;
        }
        else
            moveSpeed = 0;

       
    }

    void rotate()
    {
        GameObject tar = GameObject.Find("Tire1");

        float ret = Vector3.Angle(tar.transform.up, this.transform.forward);

        Debug.Log("tar.transform.localRotation.z  : " + tar.transform.localRotation.z);

        if (moveSpeed != 0)
        {
            //          this.transform.rotation *= Quaternion.AngleAxis(ret, Vector3.up);
            if (tar.transform.localRotation.z > 0)
            {
                this.transform.rotation *= Quaternion.AngleAxis(ret, Vector3.up);
            }
            else if (tar.transform.localRotation.z < 0)
            {
                this.transform.rotation *= Quaternion.AngleAxis(ret, Vector3.down);
            }
        }

    }

    void move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;

        
//        Debug.Log("tar.transform.rotation.y  : " + tar.transform.rotation.y);

        this.transform.Translate(transform.transform.right * moveDelta);



        //        this.transform.Translate(dir);

    }
}
