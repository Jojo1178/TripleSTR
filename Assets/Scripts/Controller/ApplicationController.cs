using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{

    public static ApplicationController INSTANCE;

    public DataBaseManager DataBaseManager;
    public MouseInputManager MouseInputManager;
    public TimeCycleManager TimeCycleManager;
    public Player MainPlayer;

    private void Awake()
    {
        INSTANCE = this;
    }
}
