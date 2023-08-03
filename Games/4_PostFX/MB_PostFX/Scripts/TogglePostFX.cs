using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TogglePostFX : MonoBehaviour
{
    public PostProcessVolume postFX;
    public bool isPostEnabled = true;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            TogglePostProcessing();
        }
    }

    public void TogglePostProcessing()
    {
        isPostEnabled = !isPostEnabled;
        postFX.isGlobal = isPostEnabled;
    }
}
