using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionalBuilding : Building
{
    public float maxLifePoint = 10;
    public Image healthBar;

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
        }
    }

    public int constructionTimeSec = 15;
    public bool pauseConstruction = false;

    public void StartConstruction()
    {
        this.healthBar.fillAmount = this._currentLifePoint / this.maxLifePoint;
        StartCoroutine(this.ContructBuilding());
    }

    private IEnumerator ContructBuilding()
    {
        float lifePerSecond = this.maxLifePoint / this.constructionTimeSec;
        float timeSpent = 0;
        while(timeSpent < this.constructionTimeSec)
        {
            if (!this.pauseConstruction)
            {
                yield return new WaitForSeconds(1);
                timeSpent += 1;
                this.CurrentLifePoint += lifePerSecond;
            }
            else
            {
                yield return null;
            }
        }
    }
}
