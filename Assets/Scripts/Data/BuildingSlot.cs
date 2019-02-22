using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;


[XmlRoot(ElementName = "resource")]
public class BuildingResource
{
    [XmlAttribute(AttributeName = "quantity")]
    public string Quantity { get; set; }
    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "resources")]
public class BuildingResources
{
    [XmlElement(ElementName = "resource")]
    public List<BuildingResource> Resource { get; set; }
}

[XmlRoot(ElementName = "building")]
public class BuildingSlot
{
    [XmlElement(ElementName = "name")]
    public string Name { get; set; }
    [XmlElement(ElementName = "Image")]
    public string Image { get; set; }
    [XmlElement(ElementName = "resources")]
    public BuildingResources Resources { get; set; }
}

[XmlRoot(ElementName = "buildings")]
public class BuildingSlots
{
    [XmlElement(ElementName = "building")]
    public List<BuildingSlot> Building { get; set; }


    public static BuildingSlots Load(string path)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BuildingSlots));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as BuildingSlots;
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Exception loading config file: " + e);

            return null;
        }
    }
}



