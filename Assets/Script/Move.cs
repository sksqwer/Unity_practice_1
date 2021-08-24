using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //   public static int moveSpeed = 0;
    public static float moveSpeed = 0.0f;
    public static float max_Speed = 30.0f;
    public static float Body_rotation = 0;
    Rigidbody rigidbody;
    int _num;
    static int n = 0;
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        _num = n;
        n++;
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move_2();
        moveSpeed = Mathf.Clamp(moveSpeed, -max_Speed, max_Speed);

        rotate();
        move();
        pos_set();
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
            moveSpeed += 1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveSpeed -= 1f;
        }
        else
            moveSpeed = 0;

       
    }

    void rotate()
    {
        GameObject tar = GameObject.Find("Tire1");

        float ret = Vector3.Angle(tar.transform.up, this.transform.forward);
        

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
//            this.transform.rotation *= Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));
        }

    }

    void move()
    {
        float moveDelta = moveSpeed * Time.deltaTime;
        
        float rot = moveSpeed * Time.deltaTime;
        Vector3 forward = Vector3.right * rot;
        forward.y = 0.0f;

        transform.Translate(forward);

    }

    void Move3()
    {
        float z = Input.GetAxis("Horizontal");
        z = z * moveSpeed * Time.deltaTime;
        gameObject.transform.Translate(Vector3.right * z);
    }

    void pos_set()
    {
        //    print("pre : " + transform.rotation.y);
        if ((transform.rotation.x < -0.1f || transform.rotation.x > 0.1f) ||
        (transform.rotation.z < -0.1f || transform.rotation.z > 0.1f))
            this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));
        // this.transform.rotation *= Quaternion.AngleAxis(1, new Vector3(-1 * transform.rotation.x, 0, -1 * transform.rotation.z));
        //        this.transform.rotation = Quaternion.AngleAxis(0.0f, Vector3.forward) *
        //           Quaternion.AngleAxis(transform.rotation.y, Vector3.up) *
        //          Quaternion.AngleAxis(0.0f, Vector3.right);

        if (transform.position.y != 0.5f)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    //    print("post : " + transform.rotation.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag != "Terrain" && hitObject.name != "Goalline")
        {
            if (hitObject.tag == "Wall")
            {
                float rot = moveSpeed * Time.deltaTime; 
                Vector3 forward = Vector3.left * rot;
                forward.y = 0.0f;

                transform.Translate(forward);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag != "Terrain" && hitObject.name != "Goalline")
        {
            if (hitObject.tag == "Wall")
            {
                float rot = moveSpeed * Time.deltaTime;
                Vector3 forward = Vector3.left * rot;
                forward.y = 0.0f;

                transform.Translate(forward);
            }
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag != "Terrain" && hitObject.name != "Goalline")
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(this.name);
        if (start)
        {
            start = false;

            Gamemanager G = Gamemanager.Instance;
            G.gameStartTime[_num] = Time.time;
            G.playerName[_num] = this.name;
        }
        else
        {
            Gamemanager G = Gamemanager.Instance;
            G.gameEndTime[_num] = Time.time;
            //       print(Gamemanager.score);
            G.gameScore[_num] = Gamemanager.score;
            Gamemanager.score -= 200;
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
