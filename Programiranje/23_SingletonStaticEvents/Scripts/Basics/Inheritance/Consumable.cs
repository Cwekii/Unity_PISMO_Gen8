using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/ConsumableItem")]
public class Consumable : Item
{

    [SerializeField, Range(0, 100)] private int healAmount;


    public override void UseItem(Object objectToUseOn)
    {
        base.UseItem(objectToUseOn);
        ConsumeItem(objectToUseOn as Health);
    }

    public void ConsumeItem(Health health)
    {
        if (health != null)
        {
            health.Heal(healAmount);
        }
        else
        {
            Debug.LogError("Health component is null or not correctly cast!");
        }
    }
}
