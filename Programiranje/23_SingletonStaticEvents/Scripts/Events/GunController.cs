using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{
    public UnityEvent<Gun> OnGunChanged;
    public UnityEvent<Gun> OnGunUsed;
    public UnityEvent OnEmptyEventRaised;
    public UnityEvent<float, int, bool> MultipleArgumentsEvent;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<Gun> guns;
    [SerializeField] private int currentGunIndex;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private string currentGunName;


    private void OnValidate()
    {
        currentGunIndex = Mathf.Clamp(currentGunIndex, 0, guns.Count - 1);
        currentGunName = guns[currentGunIndex].GunName;
    }

    private void Start()
    {
        OnGunChanged?.Invoke(guns[currentGunIndex]);
    }

    private void OnEnable()
    {
        OnGunUsed.AddListener(PlayGunSound);
    }

    private void OnDisable()
    {
        OnGunUsed.RemoveListener(PlayGunSound);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnGunUsed?.Invoke(guns[currentGunIndex]);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0.01f)
        {
            ChangeGun(true);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < -0.01f)
        {
            ChangeGun(false);
        }
    }

    private void ChangeGun(bool next)
    {
        if (next)
        {
            currentGunIndex++;
            if (currentGunIndex >= guns.Count)
            {
                currentGunIndex = 0;
            }
        }
        else
        {
            currentGunIndex--;
            if (currentGunIndex < 0)
            {
                currentGunIndex = guns.Count - 1;
            }
        }

        OnGunChanged?.Invoke(guns[currentGunIndex]);
    }

    private void PlayGunSound(Gun gun)
    {
        audioSource.PlayOneShot(gun.Sound);
    }
}