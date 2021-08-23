using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour
{
    public static float moveSpeed = 20;
    public static float max_Speed = 20;
    public float distance = 100.0f;
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
            this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
        }
        else if (lrayHits.distance < rrayHits.distance)
        {
            this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag != "Terrain" && hitObject.name != "Goalline")
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.tag != "Terrain" && hitObject.name != "Goalline")
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, transform.rotation.y, 0.0f));
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print(this.name);
        if (start)
        {
            Gamemanager G = Gamemanager.Instance;
            G.gameStartTime[_num] = Time.time;
            G.playerName[_num] = this.name;
            start = false;
        }
        else
        {
            Gamemanager G = Gamemanager.Instance;
            G.gameEndTime[_num] = Time.time;
            print(Gamemanager.score);
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
