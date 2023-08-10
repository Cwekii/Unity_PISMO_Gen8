using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldInput : MonoBehaviour
{
    [SerializeField] Text fieldText;
    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        fieldText.text = GameManager.instance.playerSide;
        button.interactable = false;
        GameManager.instance.moves++;
        GameManager.instance.EndGame();

    }
}
