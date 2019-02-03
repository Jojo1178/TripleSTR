using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    public static EntitiesController INSTANCE;

    public GameObject bank;
    public GameObject well;
    public GameObject door;
    public GameObject townHall;

    public EntitiesController()
    {

    }

    private void Awake()
    {
        EntitiesController.INSTANCE = this;
    }

    public Bank getBank()
    {
        return bank.GetComponent<Bank>();
    }

    public Well getWell()
    {
        return well.GetComponent<Well>();
    }

    public Door getDoor()
    {
        return door.GetComponent<Door>();
    }

    public TownHall getTownHall()
    {
        return townHall.GetComponent<TownHall>();
    }
}
