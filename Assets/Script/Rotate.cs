using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float speed = 0;
 //   int speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);
        //Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        //this.transform.rotation = target;
        //this.transform.Rotate(Vector3.up * 45.0f);
        //this.transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.up);
    }
    // Update is called once per frame
    void Update()
    {
        speed = Move.moveSpeed;
        Rotate_1(); Rotate_2();
    }

    void Rotate_1()
    {
        this.transform.rotation *= Quaternion.AngleAxis(speed, Vector3.down );
    }

    void Rotate_2()
    {
        float y = Input.GetAxis("Horizontal");
        y = y * speed * Time.deltaTime;
        gameObject.transform.Rotate(new Vector3(0, y, 0));
    }

    void Rotate_3()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 dir = new Vector3(10, 0, 0) - transform.position;
            Vector3 dirXZ = new Vector3(dir.x, 0.0f, dir.z);

            if(dirXZ != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(dirXZ);
                Quaternion frameRot = Quaternion.RotateTowards(transform.rotation,
                    targetRot, speed * Time.deltaTime);
                transform.rotation = frameRot;  
            }
        }
    }
}
