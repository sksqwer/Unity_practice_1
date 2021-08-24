using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour
{
    public float moveSpeed = 20;
    public float max_Speed = 30;
    public float distance = 2000.0f;
    private RaycastHit lrayHits; // 구조체
    private RaycastHit rrayHits; // 구조체
    private Ray lray;
    private Ray rray;
    Vector3 lV;
    Vector3 rV;
    Quaternion l45 = Quaternion.Euler(Vector3.up * 45);
    Quaternion r45 = Quaternion.Euler(Vector3.up * -45);
    Rigidbody rigidbody;
    int _num;
    static int n = 0;
    bool start = true;

    private Transform wallTrans = null;

    // Start is called before the first frame update
    void Start()
    {
        _num = n;
        n++;
        wallTrans = GameObject.Find("Wall").transform;
        rigidbody = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        raycast();
        Rotate();
        move();
        pos_set();
    }

    private void DrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,
            transform.position + lV * lrayHits.distance);
        Gizmos.DrawLine(transform.position,
            transform.position + rV * lrayHits.distance);
    }

    void move()
    {

        float rot = moveSpeed * Time.deltaTime;
        Vector3 forward = Vector3.right * rot;
        forward.y = 0.0f;

        transform.Translate(forward);
        if (moveSpeed < max_Speed)
            moveSpeed++;

        //        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    void Rotate()
    {
        if (lrayHits.distance > rrayHits.distance)
        {
            this.transform.rotation *= Quaternion.AngleAxis(3, Vector3.up);
        }
        else if (lrayHits.distance < rrayHits.distance)
        {
            this.transform.rotation *= Quaternion.AngleAxis(3, Vector3.down);
        }


 //       this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));

    }

    void raycast()
    {
        lV = (Vector3.forward + Vector3.right).normalized;
        rV = (Vector3.back + Vector3.right).normalized;
        lV = (l45 * transform.right).normalized;
        rV = (r45 * transform.right).normalized;

        lray = new Ray(this.transform.position, lV);
        rray = new Ray(this.transform.position, rV);


        if (Physics.Raycast(lray, out lrayHits, distance))
        {
            Debug.DrawRay(lray.origin, lV * lrayHits.distance, Color.red);
        }
        if (Physics.Raycast(rray, out rrayHits, distance))
        {
            Debug.DrawRay(rray.origin, rV * rrayHits.distance, Color.red);
        }

    }

    void pos_set()
    {
        //   print("pre : " + transform.rotation.y);
        if ((transform.rotation.x < -0.1f || transform.rotation.x > 0.1f) ||
        (transform.rotation.z < -0.1f || transform.rotation.z > 0.1f))
            this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));
        //this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));

        if (transform.position.y != 0.5f)
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
     //   print("post : " + transform.rotation.y);
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
