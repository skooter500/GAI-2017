using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : SteeringBehaviour {

    public Path path;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override Vector3 Calculate()
    {
        Vector3 nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < 3)
        {
            path.AdvanceToNext();
        }

        if (!path.looped && path.IsLast())
        {
            return boid.ArriveForce(nextWaypoint, 20);
        }
        else
        {
            return boid.SeekForce(nextWaypoint);
        }
    }
}
