using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEx : MonoBehaviour
{
    [Range(0, 50)]
    public float distance = 20.0f;
    private RaycastHit rayHit; // 구조체
    private RaycastHit[] rayHits; // 구조체
    private Ray ray;

    private Transform otherTrans = null;


    // Start is called before the first frame update
    private void Awake()
    {
        otherTrans = GameObject.Find("Other").transform;
    }

    void Start()
    {
  //      ray = new Ray();
 //       ray.origin = this.transform.position;
//        ray.direction = this.transform.forward;

        ray = new Ray(this.transform.position, this.transform.forward);





    }

    // Update is called once per frame
    void Update()
    {
      //  Ray_3();
        Ray_FindObj();
    }


    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        //Gizmos.DrawLine(ray.origin, ray.direction * distance);

        //Gizmos.color = Color.yellow;

        //Gizmos.color = new Color32(0,255,0,255);

       // Gizmos.DrawWireSphere(ray.origin, 0.1f);
        //Gizmos.DrawSphere(ray.origin, 0.1f);




        DrawGizmos();


    }

    private void DrawGizmos()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        if (rayHits != null)
        {
            for(int i = 0; i< this.rayHits.Length; i++)
            {
                if(this.rayHits[i].collider != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);

                    Gizmos.color = Color.cyan;
                    Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayHits[i].distance);


                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + rayHits[i].normal);



                    Gizmos.color = Color.magenta;
                    Vector3 reflect = Vector3.Reflect(transform.forward, rayHits[i].normal);

                    Gizmos.DrawLine(rayHits[i].point, rayHits[i].point + reflect);
                }

            }
        }

    }

    void Ray_1()
    {
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }

    }
    void Ray_2()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for(int index = 0; index < rayHits.Length; index++)
        {
               Debug.Log(rayHits[index].collider.gameObject.name + " - hit!!");
        }

    }

    void Ray_3()
    {
        rayHits = Physics.RaycastAll(ray, distance);
        for(int index = 0; index < rayHits.Length; index++)
        {
            if(rayHits[index].collider.gameObject.tag == "Box")
            {
                Debug.Log(rayHits[index].collider.gameObject.name + " - hit!! with tag");
            }

            if(rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Effect"))
            {
                Debug.Log(rayHits[index].collider.gameObject.name + " - hit!! with layer");
            }
        }

    }

    void Ray_FindObj()
    {
        Vector3 dir = otherTrans.position - this.transform.position;

        dir.Normalize();

        float dist = Vector3.Distance(otherTrans.position, this.transform.position);

        Debug.DrawRay(ray.origin, dir * dist, Color.blue);

        rayHits = Physics.SphereCastAll(ray, 1.0f, distance);
        for(int i = 0; i < rayHits.Length; i++)
        {
            if(rayHits[i].collider !=null)
            {
                //Destroy(rayHits[i].collider.gameObject);

                rayHits[i].collider.gameObject.SetActive(false);
            }
        }

    }
}
