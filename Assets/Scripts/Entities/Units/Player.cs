using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Unit
{

    public NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Debug.Log("Player start");
        this.setName("PLAYER");
    }

    private void Update()
    {
        this.CheckWalkingState();
    }

    public void Move(RaycastHit destination)
    {
        this.navMeshAgent.destination = destination.point;
        this.navMeshAgent.isStopped = false;
    }

    private void CheckWalkingState()
    {
        if (this.navMeshAgent.remainingDistance <= this.navMeshAgent.stoppingDistance)
        {
            if (!this.navMeshAgent.hasPath || Mathf.Abs(this.navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                this.navMeshAgent.isStopped = true;
        }
        else
        {
            this.navMeshAgent.isStopped = false;
        }
    }
}
