using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInputManager : MonoBehaviour
{

    private int _mouseInput = -1;

    void Update()
    {

        this._mouseInput = GetMouseInput();
        //On vérifie si il y a eu un clic de la souris:
        if (this._mouseInput != -1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                //On récupère le GameObject qui a été sélectionné:
                GameObject selectedGameObject = hit.transform.gameObject;
                string selectedGameObjectName = selectedGameObject.name;


                ISelectionableEntity selectionableEntity = selectedGameObject.GetComponent<ISelectionableEntity>();
                if (selectionableEntity != null)
                {
                    selectionableEntity.clicked(this._mouseInput);
                }
            }
        }
    }

    private int GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return 0;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            return 1;
        }
        else if (Input.GetMouseButtonDown(3))
        {
            return 2;
        }
        return -1;

    }
}
