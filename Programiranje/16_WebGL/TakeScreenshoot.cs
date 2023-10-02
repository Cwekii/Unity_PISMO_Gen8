using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class TakeScreenshoot : MonoBehaviour
{
    //Ako se treba pokrenuti kada se scena upali
    public void Start()
    {
        Screenshot();
    }

    //Ako se pokrece na gumb
    public void Screenshot()
    {
        StartCoroutine(UploadPNG());
        //Debug.log (encodedText);
    }

    IEnumerator UploadPNG()
    {
        yield return new WaitForEndOfFrame();

        // Izradi sliku
        int width = Screen.width;
        int height = Screen.height;
        var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        // Dodjeli komponente
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        // Stavi u PNG
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        string encodedText = System.Convert.ToBase64String(bytes);

        var image_url = "data:image/png;base64," + encodedText;

        Debug.Log(image_url);

#if !UNITY_EDITOR
        openWindow(image_url);
#endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}