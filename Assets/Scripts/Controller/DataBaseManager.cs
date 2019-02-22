using System.IO;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public string BuildingSlotsXMLStreamingAssetPath;
    public BuildingSlots BuildingSlots;

    private void Awake()
    {
        this.BuildingSlots = BuildingSlots.Load(Path.Combine(Application.streamingAssetsPath, this.BuildingSlotsXMLStreamingAssetPath));
    }
}
