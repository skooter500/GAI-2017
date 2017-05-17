using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Pursue : SteeringBehaviour
{
    public Boid target;

    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;

        Vector3 targetPos = target.transform.position
            + (time * target.velocity);

        return boid.SeekForce(targetPos);
    }
}
