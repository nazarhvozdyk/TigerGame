using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "TigerGame/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite sprite;
}
