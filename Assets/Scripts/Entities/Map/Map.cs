using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Map : MonoBehaviour, ISelectionableEntity
{

    public NavMeshSurface surface;

    private void Start()
    {
        this.ReBakeNavMesh();
    }

    public void clicked(int mouseInput, RaycastHit hit)
    {
        Debug.Log("MAP SELECTED (" + mouseInput + ")");
        UIManager.INSTANCE.MapSelected(this);

        if (mouseInput == 1)
        {
            // Clique droit sur la carte, on bouge le joueur
            EntitiesController.INSTANCE.getPlayer().Move(hit.point);
        }
    }

    public void ReBakeNavMesh()
    {
        this.surface.BuildNavMesh();
        //for (int i = 0; i < surfaces.Length; i++)
        //{
        //    surfaces[i].BuildNavMesh();
        //}
    }
}
