using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    IEnumerator enumerator;
    // Start is called before the first frame update
    void Start()
    {
        enumerator = TestCoroutine();
        StartCoroutine(enumerator);
        //StopCoroutine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TestCoroutine()
    {
        int i = 0;
        while (true)
        {
            print(i++);
            yield return null;
            if (i > 1000)
                yield break;
        }
    }

}
