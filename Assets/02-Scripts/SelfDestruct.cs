using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, GetComponent<AudioSource>().clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
