using UnityEngine;

[CreateAssetMenu(fileName = "Data" , menuName = "Create/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string description;
}
