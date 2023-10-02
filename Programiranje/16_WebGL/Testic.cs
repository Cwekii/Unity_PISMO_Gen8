using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Testic : MonoBehaviour
{
    public Text showText;
    public string hello;
    public InputField nameInput;

    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }


    public void ShowHello()
    {
        showText.text = hello + " " + nameInput.text + "!";
    }

    private void Update()
    {
        if(isMobile() == true)
        {
            showText.text = "Mobitel";
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(1, 1, 1);
        }
    }
}
