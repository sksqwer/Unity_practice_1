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
        moveSpeed = Mathf.Clamp(moveSpeed, -45.0f, 45.0f);
        Debug.Log("moveSpeed : " + moveSpeed);
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
        {
            if (moveSpeed > 0)
                moveSpeed -= 0.1f;
            else if (moveSpeed < 0)
                moveSpeed += 0.1f;
        }

       
    }

    void move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;

        GameObject tar = GameObject.Find("Tire1");
        GameObject tar2 = GameObject.Find("Tire3");
        Vector3 carpos = tar.transform.eulerAngles;
        //Vector3 carpos = new Vector3(0,90,90);
        Vector3 tirepos = tar.transform.forward;
        tirepos.y -= 90;
        tirepos.z -= 90;
        float ret = Vector3.Angle(tirepos, this.transform.forward);
        

        if((moveSpeed > 0 || moveSpeed < 0) && (ret >= 89 || ret <= 91) )
        {
        //    tar.transform.Rotate(Vector3.up * (ret - 90) * -1.0f);
        //    tar2.transform.Rotate(Vector3.up * (ret - 90) * -1.0f);
        //    transform.Rotate(Vector3.up * (ret - 90));
        }


        this.transform.Translate(this.transform.right * moveDelta);

        Debug.Log("Cartransform.forward : " + this.transform.right.x + this.transform.right.y
             + this.transform.right.z);


        //        this.transform.Translate(dir);

    }
}
