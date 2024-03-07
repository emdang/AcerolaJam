using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTextureFix : MonoBehaviour
{
    [SerializeField] Camera thisCam;

    [SerializeField] Camera mainCam;

    [SerializeField] Material thisCamMaterial;

    [SerializeField] Texture test;
    // Start is called before the first frame update
    void Start()
    {
        if (thisCam.targetTexture != null)
        {
            thisCam.targetTexture.Release();

        }

        if (mainCam.targetTexture != null)
        {
            mainCam.targetTexture.Release();
        }
        //thisCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //thisCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        thisCam.targetTexture.width = Screen.width;
        thisCam.targetTexture.height = Screen.height;

        thisCamMaterial.mainTexture = thisCam.targetTexture;
    }
}
