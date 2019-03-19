﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionalBuilding : Building, IWorkingEntity
{
    public float maxLifePoint = 10;
    public Image healthBar;
    public GameObject LifeBarGO;

    private float _currentLifePoint = 1;
    public float CurrentLifePoint
    {
        get => this._currentLifePoint;
        set
        {
            this._currentLifePoint = value;
            this.healthBar.fillAmount = this._currentLifePoint / this.maxLifePoint;
            if (this._currentLifePoint <= 0)
                GameObject.Destroy(this.gameObject);
            this.LifeBarGO.SetActive(this._currentLifePoint < this.maxLifePoint);
        }
    }

    public int constructionTimeSec = 15;
    public bool pauseConstruction = false;
    public bool constructed = false;

    private float lifePerSecond;
    private float timeSpent;
    private Player workingPlayer;

    public void InitBuilding(Player player)
    {
        this.healthBar.fillAmount = this._currentLifePoint / this.maxLifePoint;
        this.constructed = false;
        this.pauseConstruction = true;
        this.lifePerSecond = this.maxLifePoint / this.constructionTimeSec;
        this.timeSpent = 0;
        this.movePlayerToBuildingEntrance();
    }

    private IEnumerator ContructBuilding()
    {
        this.pauseConstruction = false;
        while (!this.pauseConstruction && timeSpent < this.constructionTimeSec)
        {
            yield return new WaitForSeconds(1);
            timeSpent += 1;
            this.CurrentLifePoint += lifePerSecond;

        }
        if (timeSpent >= this.constructionTimeSec)
            this.finishWork(this.workingPlayer);
    }

    public override void clicked(int mouseInput, RaycastHit hit)
    {
        //base.clicked(mouseInput, hit);
        Debug.Log("Optionnal BUILDING SELECTED (" + mouseInput + ")" + this.GetType());
        this.movePlayerToBuildingEntrance();
    }

    protected override void movePlayerToBuildingEntrance()
    {
        EntitiesController.INSTANCE.getPlayer().MoveAndDo(this.getClosestEntryPoint(EntitiesController.INSTANCE.getPlayer().transform.position), (player) =>
        {
            if (!this.constructed)
            {
                this.resumeWork(player);
            }
            else
            {
                Debug.LogWarning("Nothing to do with this building " + this.GetType());
            }
        });
    }

    public void resumeWork(Player player)
    {
        if (!this.constructed && this.pauseConstruction)
        {
            this.workingPlayer = player;
            this.workingPlayer.PlayerStartMovingDelegate += stopWork;
            StartCoroutine(this.ContructBuilding());
        }
    }

    public void stopWork(Player player)
    {
        this.pauseConstruction = true;
        this.workingPlayer.PlayerStartMovingDelegate -= stopWork;
        this.workingPlayer = null;
    }

    public void finishWork(Player player)
    {
        this.constructed = true;
        this.workingPlayer.PlayerStartMovingDelegate -= stopWork;
        this.workingPlayer = null;
    }
}
