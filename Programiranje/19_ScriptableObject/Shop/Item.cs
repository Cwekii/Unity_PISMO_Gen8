using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    public TextMeshProUGUI itemName;

    public void Prikazi()
    {
        Debug.Log(itemData.GetName);
        
        itemName.text = itemData.GetName;
        Debug.Log(itemData.GetDescription);
        Debug.Log(itemData.GetLevel);
        Debug.Log(itemData.GetSize);
        Debug.Log(itemData.GetPrice);
    }
}
