using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NoiseWander: SteeringBehaviour
{

    [Range(0, Mathf.PI)]
    public float range = Mathf.PI;

    private Vector3 target = Vector3.zero;
    [Range(0.0f, 500.0f)]
    public float radius = 50.0f;

    [Range(0.0f, 500.0f)]
    public float distance = 5.0f;
    
    [Range(0.001f, 1.0f)]
    public float noisiness = 0.2f;


    private float noise = 0.0f;

    public void Start()
    {
        noise = UnityEngine.Random.Range(0, 1000);
    }

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.yellow;
            Vector3 wanderCircleCenter = transform.TransformPoint(Vector3.forward * distance);
            Gizmos.DrawWireSphere(wanderCircleCenter, radius);
            Vector3 worldTarget = transform.TransformPoint(target + Vector3.forward * distance);
            Gizmos.DrawLine(transform.position, worldTarget);
        }
    }

    public override Vector3 Calculate()
    {
        float n = Mathf.PerlinNoise(noise, 0);
        float theta = Utilities.Map(n, 0.0f, 1.0f, Mathf.PI - range, Mathf.PI + range);
        target.x = Mathf.Sin(theta);
        target.z = -Mathf.Cos(theta);        
        target.y = 0;
        target *= radius;
        Vector3 localTarget = target + (Vector3.forward * distance);
        Vector3 worldTarget = transform.TransformPoint(localTarget);

        noise += noisiness * Time.deltaTime;
        Vector3 desired = worldTarget - transform.position;
        desired.Normalize();
        desired *= boid.maxSpeed;
        //return Vector3.zero;
        return desired - boid.velocity;
    }
}