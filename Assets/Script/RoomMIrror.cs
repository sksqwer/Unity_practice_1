using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMIrror : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();

    }


    private void OnPreCull()
    {
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));

    }

    private void OnPreRender()
    {
        GL.invertCulling = true;
    }

    private void OnPostRender()
    {
        GL.invertCulling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
