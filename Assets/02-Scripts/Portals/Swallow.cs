using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swallow : MonoBehaviour
{
    [SerializeField] GameData data;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    [SerializeField] float currentSize;
    [SerializeField] float targetSize;
    [SerializeField] float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.localScale = new Vector3();
    }
}
