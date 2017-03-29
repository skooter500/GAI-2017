using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState:State
{
    public override void Enter()
    {
        fsm.GetComponent<FollowPath>().enabled = true;
    }

    public override void Exit()
    {
        fsm.GetComponent<FollowPath>().enabled = false;
    }
}

public class AttackState : State
{
    public override void Enter()
    {
        fsm.GetComponent<OffsetPursue>().enabled = true;
        fsm.GetComponent<OffsetPursue>().leader = 
            GameObject.FindGameObjectWithTag("predator").GetComponent<Boid>();
        PreyStateMachine psm = (PreyStateMachine)fsm;
        psm.StartCoroutine(psm.Attack());
    }

    public override void Exit()
    {
        fsm.GetComponent<OffsetPursue>().enabled = false;
    }
}

public class PreyStateMachine : StateMachine {

	// Use this for initialization
	void Start () {
        ChangeState(new PatrolState());
	}
	
	// Update is called once per frame
	void Update () {		
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "predator")
        {
            ChangeState(new AttackState());
        }
    }

    public System.Collections.IEnumerator Attack()
    {
        while (true)
        {

        }
    }
}
