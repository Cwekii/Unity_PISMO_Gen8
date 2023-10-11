using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/BaseItem")]
public class Item : ScriptableObject
{
    [SerializeField] protected string itemName;
    [SerializeField, TextArea(5, 10)] protected string itemDescription;
    [SerializeField] protected Sprite itemIcon;

    public virtual void UseItem(Object objectToUseOn) 
    {
        Debug.Log(itemName + " used on " + objectToUseOn.name + "!");
    }


    private void OnValidate()
    {
        itemName = name;
    }

}
