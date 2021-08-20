using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    float rotate = 10;
    float speedRotate = 100;
    float speedMove = 10;

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move_Rotate();
    }

    public void Move_Rotate()
    {
        float rot = Input.GetAxis("Horizontal");
        float move = Input.GetAxis("Vertical");

        rotate = rot * speedRotate * Time.deltaTime;
        move = move * speedMove * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up * rotate);
        gameObject.transform.Translate(Vector3.forward * move);


    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name != "Plane")
            print("Collider : " + hitObject.name + "客 面倒 矫累");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if (hitObject.name != "Plane")
            print("Collider : " + hitObject.name + "客 面倒 吝");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        if(hitObject.name != "Plane")
           print("Collider : " + hitObject.name + "客 面倒 场");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.name != "Plane")
            print("Trigger : " + hitObject.name + "客 面倒 矫累");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.name != "Plane")
            print("Trigger : " + hitObject.name + "客 面倒 吝");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.name != "Plane")
            print("Trigger : " + hitObject.name + "客 面倒 场");
    }
}
