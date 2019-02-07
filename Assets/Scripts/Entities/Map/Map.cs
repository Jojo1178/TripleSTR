using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour, ISelectionableEntity
{

    //public Navme [] surfaces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked(int mouseInput, RaycastHit hit)
    {
        Debug.Log("MAP SELECTED (" + mouseInput + ")");
        UIManager.INSTANCE.MapSelected(this);

        if (mouseInput == 1)
        {
            // Clique droit sur la carte, on bouge le joueur
            ApplicationController.INSTANCE.MainPlayer.Move(hit.point);
        }
    }

    //public void ReBakeNavMesh()
    //{
    //    for (int i = 0; i < surfaces.Length; i++)
    //    {
    //        surfaces[i].BuildNavMesh();
    //    }
    //}
}
