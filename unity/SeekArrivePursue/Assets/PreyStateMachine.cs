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
        fsm.GetComponent<OffsetPursue>().leader =
            GameObject.FindGameObjectWithTag("predator").GetComponent<Boid>();
        fsm.GetComponent<OffsetPursue>().enabled = true;
        PreyStateMachine psm = (PreyStateMachine)fsm;
        psm.StartCoroutine(psm.Attack());
    }

    public override void Exit()
    {
        fsm.GetComponent<OffsetPursue>().enabled = false;
    }
}

public class PreyStateMachine : StateMachine {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        ChangeState(new PatrolState());
	}
	
	// Update is called once per frame
	void Update () {		
	}

    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger");
        if (c.tag == "predator")
        {
            ChangeState(new AttackState());
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "predator")
        {
            ChangeState(new PatrolState());
        }
    }

    public System.Collections.IEnumerator Attack()
    {
        while (state is AttackState)
        {

            GameObject bullet = GameObject.Instantiate(bulletPrefab);
            bullet.transform.position = transform.position
                + transform.forward;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
