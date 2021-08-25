using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animation spartanKing;
    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;


    }

    // Update is called once per frame
    void Update()
    {
        //AnimationPlay_1();
        AnimationPlay_2();
    }

    private void AnimationPlay_2()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.6f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.Play("attack");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.Play("idle");
        }
    }

    private void AnimationPlay_1()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            spartanKing.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            spartanKing.Play("walk");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            spartanKing.Play("run");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            spartanKing.Play("charge");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            spartanKing.Play("idlebattle");
        if (Input.GetKeyDown(KeyCode.Alpha6))
            spartanKing.Play("resist");
        if (Input.GetKeyDown(KeyCode.Alpha7))
            spartanKing.Play("victory");
        if (Input.GetKeyDown(KeyCode.Alpha8))
            spartanKing.Play("salute");
        if (Input.GetKeyDown(KeyCode.Alpha9))
            spartanKing.Play("die");
        if (Input.GetKeyDown(KeyCode.Alpha0))
            spartanKing.Play("diehard");
        if (Input.GetKeyDown(KeyCode.F))
            spartanKing.Play("attack");
    }
}
