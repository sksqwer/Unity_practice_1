using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animation spartanKing;

    private IEnumerator ani_enumerator;
    CharacterController pcControl;
    Vector3 velocity;
    float runSpeed = 5.0f;
    float rotSpeed = 50.0f;

    public GameObject objSword;

    // Start is called before the first frame update
    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        spartanKing.wrapMode = WrapMode.Loop;

        pcControl = gameObject.GetComponent<CharacterController>();


        InvokeRepeating("Invoke_Attack", 2.0f, 1.0f);


        //IsInvoking("Invoke_Attack");
        //CancelInvoke("Invoke_Attack");
        


    }

    void Invoke_Attack()
    {
        StartCoroutine("AttackToldle");
    }

    // Update is called once per frame
    void Update()
    {
        //AnimationPlay_1();
        //AnimationPlay_2();
        //AnimationPlay_3();
        CharacterControl();
    }

    private void CharacterControl()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        velocity *= runSpeed;

        if(velocity.magnitude > 0.5)
        {
            spartanKing.CrossFade("run", 0.3f);
            Vector3 forward = Vector3.Slerp(transform.forward, velocity, rotSpeed * Time.deltaTime / Vector3.Angle(transform.forward, velocity));
            transform.LookAt(transform.position + forward);
        }
        else
        {
            spartanKing.CrossFade("idle", 0.3f);
        }

        //pcControl.Move(velocity * Time.deltaTime + Physics.gravity * Time.deltaTime);
        pcControl.SimpleMove(velocity);


    }

    IEnumerator AttackToldle()
    {
        if(spartanKing.IsPlaying("attack")) yield break;

        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.6f);
        objSword.SetActive(true);

        float delayTime = spartanKing.GetClip("attack").length - 0.6f;

        yield return new WaitForSeconds(delayTime);
        objSword.SetActive(false);

        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade("idle", 0.3f);
    }

    IEnumerator AnimationToldle(string nextclip, string next_next_clip = "idle", WrapMode wrp = WrapMode.Once,
        WrapMode nextwrp = WrapMode.Loop, float fade_time = 0.3f, float next_fade_time = 0.3f)
    {
        if (spartanKing.IsPlaying(nextclip)) yield break;

        spartanKing.wrapMode = wrp;
        spartanKing.CrossFade(nextclip, fade_time);

        float delayTime = spartanKing.GetClip(nextclip).length - fade_time;

        //spartanKing[nextclip].normalizedTime; // 0 ~ 1

        yield return new WaitForSeconds(delayTime);

        spartanKing.wrapMode = nextwrp;
        spartanKing.CrossFade(next_next_clip, next_fade_time);
    }
    private void AnimationPlay_3()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ani_enumerator = AttackToldle();//AnimationToldle("attack", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ani_enumerator = AnimationToldle("idle", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ani_enumerator = AnimationToldle("walk", "walk", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ani_enumerator = AnimationToldle("run", "run", WrapMode.Once, WrapMode.Loop, 0.1f, 0.1f);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ani_enumerator = AnimationToldle("charge", "charge", WrapMode.Once, WrapMode.Loop, 0.2f, 0.2f);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ani_enumerator = AnimationToldle("idlebattle", "idlebattle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ani_enumerator = AnimationToldle("resist", "idlebattle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ani_enumerator = AnimationToldle("victory", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ani_enumerator = AnimationToldle("salute", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ani_enumerator = AnimationToldle("die", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ani_enumerator = AnimationToldle("diehard", "idle", WrapMode.Once, WrapMode.Loop);
            StartCoroutine(ani_enumerator);
        }
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
