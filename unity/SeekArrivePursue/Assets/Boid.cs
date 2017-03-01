using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();
    
    public Vector3 force = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;
    public Vector3 velocity = Vector3.zero;
    public float mass = 1;
    public float maxSpeed = 5.0f;

    // Seek fields
    public bool seekEnabled = false;
    public Vector3 seekTargetPos;
    public GameObject seekTarget;

    public bool arriveEnabled = false;
    public Vector3 arriveTargetPos;
    public GameObject arriveTarget;
    public float slowingDistance = 5;

    // Offset Pursue
    public bool offsetPursueEnabled;
    public Boid leader;
    private Vector3 offset;

    public bool followPathEnabled = false;
    public Path path;
    
    // Use this for initializationG
    void Start () {

        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in behaviours)
        {
            this.behaviours.Add(b);
        }


        if (offsetPursueEnabled)
        {
            offset = transform.position- leader.transform.position;
            offset = Quaternion.Inverse(leader.transform.rotation) * offset;
        }
	}

    Vector3 Pursue(Boid target)
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / maxSpeed;

        Vector3 targetPos = target.transform.position
            + (time * target.velocity);

        return Seek(targetPos);
    }

    Vector3 FollowPath()
    {
        Vector3 nextWaypoint = path.NextWaypoint();
        if (Vector3.Distance(transform.position, nextWaypoint) < 3)
        {
            path.AdvanceToNext();
        }

        if (!path.looped && path.IsLast())
        {
            return Arrive(nextWaypoint);
        }
        else
        {
            return Seek(nextWaypoint);
        }
    }

    Vector3 OffsetPursue(Boid target, Vector3 offset)
    {
        Vector3 worldtarget = target.transform.TransformPoint(offset);
        float dist = Vector3.Distance(worldtarget
            , transform.position);
        float time = dist / maxSpeed;

        Vector3 targetPos = worldtarget + (target.velocity * time);
        return Arrive(targetPos);
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired- velocity;
    }

    Vector3 Arrive(Vector3 target)
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        float ramped = maxSpeed * (distance / slowingDistance);
        float clamped = Mathf.Min(ramped, maxSpeed);
        Vector3 desiredVelocity = clamped * (toTarget / distance);
        return desiredVelocity - velocity;
    }


    Vector3 Calculate()
    {
        force = Vector3.zero;

        force = Calculate();

        /*
        if (seekEnabled)
        {
            if (seekTarget != null)
            {
                seekTargetPos = seekTarget.transform.position;
            }
            force += Seek(seekTargetPos);
        }
        if (arriveEnabled)
        {
            if (arriveTarget != null)
            {
                arriveTargetPos = arriveTarget.transform.position;
            }
            force += Arrive(arriveTargetPos);
        }
        if (offsetPursueEnabled)
        {
            force += OffsetPursue(leader, offset);
        }

        if (followPathEnabled)
        {
            force += FollowPath();
        }
        */

        return force;
    }
	
	// Update is called once per frame
	void Update () {
        force = Calculate();

        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        if (velocity.magnitude > float.Epsilon)
        {
            transform.forward = velocity;
        }

        transform.position += velocity * Time.deltaTime;
        

	}
}
