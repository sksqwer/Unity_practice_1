using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //   public static int moveSpeed = 0;
    public static float moveSpeed = 1000.0f;
    public static float max_Speed = 5000.0f;
    public static float Body_rotation = 0;
    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0.0f, 3.0f, 0.0f);
        // this.transform.Translate( new Vector3(0.0f, 3.0f, 0.0f));
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move_2();
        moveSpeed = Mathf.Clamp(moveSpeed, -max_Speed, max_Speed);
        Debug.Log("moveSpeed : " + moveSpeed);
        rotate();
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
            moveSpeed += 100f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveSpeed -= 100f;
        }
        else
            moveSpeed = 0;

       
    }

    void rotate()
    {
        GameObject tar = GameObject.Find("Tire1");

        float ret = Vector3.Angle(tar.transform.up, this.transform.forward);

        Debug.Log("tar.transform.localRotation.z  : " + tar.transform.localRotation.z);

        if (moveSpeed != 0 && ret != 0)
        {
            //          this.transform.rotation *= Quaternion.AngleAxis(ret, Vector3.up);
            if (tar.transform.localRotation.z > 0)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                   this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
                else
                   this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
            }
            else if (tar.transform.localRotation.z < 0)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                    this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
                else
                    this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
            }
        }

    }

    void move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;

        
//        Debug.Log("tar.transform.rotation.y  : " + tar.transform.rotation.y);

  //      this.transform.Translate(Vector3.right * moveDelta);
        if (rigidbody.velocity.magnitude < max_Speed)
        {
            float rot = moveSpeed * Time.deltaTime;
            Vector3 forward = transform.right * rot;
            forward.y = 0;
            rigidbody.AddForce(forward);
        }


        //        this.transform.Translate(dir);

    }

    void Move3()
    {
        float z = Input.GetAxis("Horizontal");
        z = z * moveSpeed * Time.deltaTime;
        gameObject.transform.Translate(Vector3.right * z);
    }
}
