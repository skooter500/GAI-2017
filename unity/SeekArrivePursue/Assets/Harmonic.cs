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
    }

    public virtual void OnDrawGizmos()
    {
        if (isActiveAndEnabled)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, worldTarget);
            Vector3 yawRoll = transform.rotation.eulerAngles;
            yawRoll.x = 0;

            Vector3 center = transform.position + (Quaternion.Euler(yawRoll) * Vector3.forward * distance);
            Gizmos.DrawWireSphere(center, radius);
        }
    }

    public override Vector3 Calculate()
    {

        float angle = Mathf.Sin(theta) * Utilities.DegreesToRads(amplitude);
        Vector3 target = new Vector3();

        if (direction == Axis.Horizontal)
        {
            target.x = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
        }
        else
        {
            target.y = Mathf.Sin(angle);
            target.z = Mathf.Cos(angle);
        }
        target *= radius;
        //
        Vector3 localTarget = (Vector3.forward * distance) + target;

        Vector3 yawRoll = transform.rotation.eulerAngles;
        yawRoll.x = 0;

        //worldTarget = transform.TransformPoint(target);
        worldTarget = transform.position + (Quaternion.Euler(yawRoll) * localTarget);

        

        this.theta += Time.deltaTime * frequency * Utilities.TWO_PI;

        return boid.SeekForce(worldTarget);
        //return Vector3.zero;
    }
}
