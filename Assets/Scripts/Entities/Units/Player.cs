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

    private delegate void OnDestinationReached(Player sender);
    private event OnDestinationReached DestinationReachedDelegate;

    public delegate void OnPlayerStartMoving(Player sender);
    public event OnPlayerStartMoving PlayerStartMovingDelegate;

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

    public void MoveAndDo(Vector3 destination, Action<Player> onDestinationReached)
    {
        this.DestinationReachedDelegate = null;
        this.DestinationReachedDelegate += new OnDestinationReached(onDestinationReached);
        this.StartMoving(destination);
    }

    public void Move(Vector3 destination)
    {
        this.DestinationReachedDelegate = null;
        this.StartMoving(destination);
    }

    private void StartMoving(Vector3 destination)
    {
        this.PlayerStartMovingDelegate?.Invoke(this);
        this.navMeshAgent.destination = destination;
        this.navMeshAgent.isStopped = false;
    }

    private void CheckWalkingState()
    {
        if (!this.navMeshAgent.pathPending)
        {
            if (this.navMeshAgent.remainingDistance <= this.navMeshAgent.stoppingDistance)
            {
                if (this.navMeshAgent.hasPath || Mathf.Abs(this.navMeshAgent.velocity.sqrMagnitude) < float.Epsilon)
                {
                    this.navMeshAgent.isStopped = true;
                    this.navMeshAgent.ResetPath();
                    this.DestinationReachedDelegate?.Invoke(this);
                    this.DestinationReachedDelegate = null;
                }
            }
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
