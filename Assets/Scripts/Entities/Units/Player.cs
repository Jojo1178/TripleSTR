using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Unit
{

    public NavMeshAgent navMeshAgent;

    private int playerInventoryLineNumber = 1;
    private int playerInventoryColumnNumber = 6;

    private int playerInventorySize;
    private UsableObject[] playerInventory;

    private delegate void OnDestinationReached();
    private event OnDestinationReached DestinationReachedDelegate;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Debug.Log("Player start");
        this.setName("PLAYER");

        playerInventorySize = playerInventoryLineNumber * playerInventoryColumnNumber;
        playerInventory = new UsableObject[playerInventorySize];

        //FOR TEST PURPOSE:
        O_WaterBottle waterBottle = new O_WaterBottle(0);
        playerInventory[2] = waterBottle;
    }

    private void Update()
    {
        this.CheckWalkingState();
    }

    public void MoveAndDo(Vector3 destination, Action onDestinationReached)
    {
        this.DestinationReachedDelegate = null;
        this.DestinationReachedDelegate += new OnDestinationReached(onDestinationReached);
        this.Move(destination);
    }

    public void Move(Vector3 destination)
    {
        this.navMeshAgent.destination = destination;
        this.navMeshAgent.isStopped = false;
    }

    private void CheckWalkingState()
    {
        if (this.navMeshAgent.remainingDistance <= this.navMeshAgent.stoppingDistance)
        {
            if (!this.navMeshAgent.hasPath || Mathf.Abs(this.navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
            {
                this.navMeshAgent.isStopped = true;
                this.DestinationReachedDelegate?.Invoke();
                this.DestinationReachedDelegate = null;
            }
        }
        else
        {
            this.navMeshAgent.isStopped = false;
        }
    }

    public bool addObjectToPlayerInventory(UsableObject objectToAdd)
    {
        for (int i = 0; i < playerInventory.Length; i++)
        {
            if (playerInventory[i] == null)
            {
                playerInventory[i] = objectToAdd;
                return true;
            }
        }
        return false;
    }

    public void removeObjectFromPlayerInventory(int inventoryId)
    {
        playerInventory[inventoryId] = null;
    }

    public UsableObject[] getPlayerInventory()
    {
        return this.playerInventory;
    }

    public int getPlayerInventoryLineNumber()
    {
        return playerInventoryLineNumber;
    }

    public int getPlayerInventoryColumnNumber()
    {
        return playerInventoryColumnNumber;
    }
}
