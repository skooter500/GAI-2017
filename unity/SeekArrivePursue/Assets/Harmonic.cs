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
    }

    public override Vector3 Calculate()
    {
        return Vector3.zero;
    }
}
