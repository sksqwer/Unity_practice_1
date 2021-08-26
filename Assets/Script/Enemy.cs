using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponentInChildren<Animation>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Attack");
        if(other.tag == "Sword")
        {
            animation.Play("die");
            Destroy(this.gameObject, 1.0f);
        }
    }
}
