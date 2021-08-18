using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCall_Test : MonoBehaviour
{
    private void Awake()
    {
        print("Awake Called~!");
    }

    private void OnEnable()
    {
        print("OnEnable Called~!");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Start Called~!");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update Called~!");
    }

    private void Lateupdate()
    {
        print("LateUpdate Call~!");
    }

    private void FixedUpdate()
    {
        print("FixedUpdate Call~!");
    }

    private void OnDisable()
    {
        print("OnDisable Called~!");
    }

    private void OnDestroy()
    {
        print("OnDestroy Called~!");
    }

    private void OnBecameInvisible()
    {
        print("OnBecameInvisible Called~!");
    }

    private void OnBecameVisible()
    {
        print("OnBecameVisible Called~!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(1, 1, 1));
    }

    private void OnGUI() // µð¹ö±ë¿ë
    {

        print("OnGUI Called~!");
    }

}
