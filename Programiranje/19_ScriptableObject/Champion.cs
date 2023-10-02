using UnityEngine;

[CreateAssetMenu(fileName = "Champion", menuName = "TestniScrpitable/New Champion", order = 600)]
public class Champion : ScriptableObject
{
    public Sprite championImage;
    public string championName;
    [Range(100, 500)]
    public float health;
    [Range(0f, 100f)]
    public float mana;
    [Range(0f, 100f)]
    public float energy;
    [Range(0, 50)]
    public int magicResist;
    [Range(0, 50)]
    public int armor;
    [Range(10, 70)]
    public int abilityPowerDamage;
    [Range(10, 70)]
    public int attackDamage;
    public string namePowerQ;
    public string namePowerW;
    public string namePowerE;
    public string namePowerR;
}
