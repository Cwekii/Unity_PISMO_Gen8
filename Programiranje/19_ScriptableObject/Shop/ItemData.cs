using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string itemDescription;
    [SerializeField]
    private int itemPrice;
    [SerializeField]
    private int itemReqLevel;
    [SerializeField]
    private int itemInventorySize;

    public string GetName
    {
        get
        {
            return itemName;
        }
    }
    public string GetDescription
    {
        get
        {
            return itemDescription;
        }
    }
    public int GetPrice
    {
        get
        {
            return itemPrice;
        }
    }
    public int GetLevel
    {
        get
        {
            return itemReqLevel;
        }
    }
    public int GetSize
    {
        get
        {
            return itemInventorySize;
        }
    }
}
