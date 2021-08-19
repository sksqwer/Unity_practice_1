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
        Rotate_1();
    }

    void Rotate_1()
    {
        float rot = speed * Time.deltaTime;
        
        //this.transform.Rotate(Vector3.up * rot);
        this.transform.rotation *= Quaternion.AngleAxis(speed, Vector3.down );

    }
}
