using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Wander : SteeringBehaviour
{
    public float radius = 10.0f;
    public float distance = 15.0f;
    public float jitter = 5.0f;
    private Vector3 target;



    public void Start()
    {
        target = Random.insideUnitSphere * radius;
    }

    public override Vector3 Calculate()
    {
        float jitterTimeSlice = jitter * Time.deltaTime;

        Vector3 toAdd = Random.insideUnitSphere * jitterTimeSlice;
        target += toAdd;
        target.Normalize();
        target *= radius;

        Vector3 localTarget = target + Vector3.forward * distance;

        Vector3 worldTarget = boid.transform.TransformPoint(localTarget);

        return (worldTarget - boid.transform.position);

        
    }
}