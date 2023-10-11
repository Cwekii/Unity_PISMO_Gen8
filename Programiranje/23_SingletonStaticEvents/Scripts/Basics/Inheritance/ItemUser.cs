using UnityEngine;

public class ItemUser : MonoBehaviour
{
    [SerializeField] private Item currentItem;
    [SerializeField] private Object objectToUseOn;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.UseItem(objectToUseOn);
        }
    }
}
