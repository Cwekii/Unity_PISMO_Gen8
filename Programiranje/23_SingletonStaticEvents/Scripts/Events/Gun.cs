using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Gun")]
public class Gun : ScriptableObject
{
    [SerializeField] private string gunName;
    [SerializeField] private Sprite icon;
    [SerializeField] private float range;
    [SerializeField] private AudioClip sound;

    public string GunName => gunName;
    public Sprite Icon => icon;
    public float Range => range;
    public AudioClip Sound => sound;

    public void ChangeRange(float newRange)
    {
        range = Mathf.Clamp(newRange, 5f, 200f);
    }
}
