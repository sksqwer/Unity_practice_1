using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Move : MonoBehaviour
{
    public static float moveSpeed = 10.0f;
    public static float max_Speed = 10.0f;
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

    private Transform wallTrans = null;

    // Start is called before the first frame update
    void Start()
    {
        wallTrans = GameObject.Find("Wall").transform;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lV = (Vector3.forward + Vector3.right).normalized;
        rV = (Vector3.back + Vector3.right).normalized;
        lV = (l45 * transform.right).normalized;
        rV = (r45 * transform.right).normalized;

        lray = new Ray(this.transform.position, lV);
        rray = new Ray(this.transform.position, rV);
       
//        lV = transform.right;
//        rV = transform.right;

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
        //if (rigidbody.velocity.magnitude < max_Speed)
        //{
        //    float rot = moveSpeed * Time.deltaTime;
        //    rigidbody.AddForce(forward);
        //}
                float rot = moveSpeed * Time.deltaTime;
        Vector3 forward = transform.right * rot;
        forward.y = 0;
        //transform.position.set(transform.position.x, 0.0f, transform.position.z);
        transform.Translate(forward);
    }

    void Rotate()
    {
        if(lrayHits.distance > rrayHits.distance)
        {
  //          transform.eulerAngles = new Vector3(0.0f, transform.rotation.y, 0.0f);

            this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.up);
       }
        else if(lrayHits.distance < rrayHits.distance)
        {
 //           transform.eulerAngles = new Vector3(0.0f, transform.rotation.y, 0.0f);

            this.transform.rotation *= Quaternion.AngleAxis(1, Vector3.down);
 //           transform.eulerAngles = new Vector3(0.0f, transform.rotation.y, 0.0f);
        }
    }

    void raycast()
    {
        
        if (Physics.Raycast(lray, out lrayHits, distance))
        {
            Debug.DrawRay(lray.origin, lV * lrayHits.distance, Color.red);
        }
        if (Physics.Raycast(rray, out rrayHits, distance))
        {
            Debug.DrawRay(rray.origin, rV * rrayHits.distance, Color.red);
        }
        
    }
}
