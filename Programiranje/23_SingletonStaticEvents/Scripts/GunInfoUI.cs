using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunInfoUI : MonoBehaviour
{
    [SerializeField] private Image gunImage;
    [SerializeField] private TextMeshProUGUI gunName;
    [SerializeField] private GunController gunController;

    private void OnEnable()
    {
        gunController.OnGunChanged.AddListener(ChangeGunDisplay);
    }

    private void OnDisable()
    {
        gunController.OnGunChanged.RemoveListener(ChangeGunDisplay);
    }


    private void ChangeGunDisplay(Gun newGun)
    {
        gunImage.sprite = newGun.Icon;
        gunName.text = newGun.GunName;
    }
}
