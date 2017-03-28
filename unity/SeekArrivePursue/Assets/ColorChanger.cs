using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
    public Color start = Color.blue;
    public Color end = Color.red;

    public float time = 3;
    public float updatesPerSecond = 20;

    System.Collections.IEnumerator UpdateColor()
    {
        float t = 0;
        Renderer r = GetComponent<Renderer>();
        float tInc = 1.0f / (time * updatesPerSecond);
        while (t < 1.0f)
        {
            yield return new WaitForSeconds(1.0f / updatesPerSecond);
            r.material.color = Color.Lerp(start, end, t);
            t += tInc;
        }
        Debug.Log("Finished!");
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(UpdateColor());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
