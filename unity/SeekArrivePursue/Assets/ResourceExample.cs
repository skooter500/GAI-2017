using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceExample : MonoBehaviour {
    public int count = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(IncCount());
	}

    System.Collections.IEnumerator IncCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            count++;
        }
    }

    float acc = 0;
	// Update is called once per frame
	void Update () {
        /*
        acc += Time.deltaTime;
        if (acc > 1.0f)
        {
            count++;
            acc = 0;
        }
        */
	}
}
