using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float jumpPower = 5.0f;
    Bird_gameManager g;
    // Start is called before the first frame update
    void Start()
    {
        g = Bird_gameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }
        if(this.transform.position.y <= -13)
            next_Scene();
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            next_Scene();
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Pass")
        {
            g.score++;
        }
    }

    void next_Scene()
    {
        GameObject gobj = GameObject.Find("Spawner");
        Destroy(gobj);



        SceneManager.LoadScene("Bird_Result");
    }
}
