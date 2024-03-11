using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTexture : MonoBehaviour
{
    [SerializeField] Material miniMapMat;
    [SerializeField] Camera miniMapCam;
    [SerializeField] UnityEngine.RenderTexture rt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        miniMapCam.targetTexture = rt;
        miniMapCam.Render();
        miniMapCam.targetTexture = null;
    }
}
