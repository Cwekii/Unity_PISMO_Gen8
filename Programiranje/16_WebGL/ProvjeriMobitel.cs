using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ProvjeriMobitel : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
    #if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
    #endif
        return false;
    }

    private void Start()
    {
        if(isMobile() == true)
        {
            //Na mobitelu je
        }
        else
        {
            //Na pc-u je
        }
    }
}
