using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Harmonic:SteeringBehaviour
{
    public float frequency = 1.0f;
    public float amplitude = 50;
    public Axis direction = Axis.Horizontal;
    public enum Axis { Horizontal, Vertical };

    [HideInInspector]
    public float theta = 0.0f;

    [HideInInspector]
    protected Vector3 target = Vector3.zero;

    [HideInInspector]
    public float rampedFrequency = 0;
    [HideInInspector]
    public float rampedAmplitude = 0;
    [Range(0.0f, 500.0f)]
    public float radius = 50.0f;

    [Range(-500.0f, 500.0f)]
    public float distance = 5.0f;
  
    private Vector3 worldTarget;

    public virtual void Start()
    {
        theta = UnityEngine.Random.Range(0, Mathf.PI);
    }

    public virtual void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.blue;
            Vector3 yawRoll = transform.rotation.eulerAngles;
            yawRoll.x = 0;
            Vector3 center = transform.position + Quaternion.Euler(yawRoll) * (Vector3.forward * distance);
            Gizmos.DrawWireSphere(center, radius);
            Gizmos.color = Color.blue;
            if (worldTarget != Vector3.zero)
            {
                Gizmos.DrawLine(transform.position, worldTarget);
            }
        }
    }

    public static float Map(float value, float r1, float r2, float m1, float m2)
    {
        float dist = value - r1;
        float range1 = r2 - r1;
        float range2 = m2 - m1;
        return m1 + ((dist / range1) * range2);
    }

    public override Vector3 Calculate()
    {
        float n = Mathf.Sin(this.theta);
        rampedAmplitude = Mathf.Lerp(rampedAmplitude, amplitude, Time.deltaTime);

        float t = Map(n, -1.0f, 1.0f, -rampedAmplitude, rampedAmplitude);
        float theta = Utilities.DegreesToRads(t);

        if (direction == Axis.Horizontal)
        {
            target.x = Mathf.Sin(theta);
            target.z = Mathf.Cos(theta);
            target.y = 0;
        }
        else
        {
            target.y = Mathf.Sin(theta);
            target.z = Mathf.Cos(theta);
            target.x = 0;
        }

        target *= radius;
       
        Vector3 yawRoll = transform.rotation.eulerAngles;
        yawRoll.x = 0;

        Vector3 localTarget = target + (Vector3.forward * distance);
        //Vector3 worldTarget = boid.TransformPoint(localTarget);

        worldTarget = transform.position + Quaternion.Euler(yawRoll) * localTarget;

        rampedFrequency = Mathf.Lerp(rampedFrequency, frequency, Time.deltaTime);
        this.theta += Time.deltaTime * rampedFrequency * Utilities.TWO_PI;
        return boid.SeekForce(worldTarget);
    }
}
