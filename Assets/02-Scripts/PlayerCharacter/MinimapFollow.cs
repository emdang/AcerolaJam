using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float mapBounds = 5f;
    Vector3 pos;
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material distanceMaterial;
    [SerializeField] Image sprite;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("MinimapCam").transform; //this is bad i know
    }

    private void Update()
    {
        //basic update
        pos = transform.parent.transform.position;
        pos.y = transform.position.y;
        transform.position = pos;
        sprite.color = Color.green;
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void LateUpdate()
    {
        // calculate distance
        Vector2 this2D = new Vector2(transform.position.x, transform.position.z);
        Vector2 target2D = new Vector2(targetTransform.position.x, targetTransform.position.z);
        float Distance = Vector2.Distance(this2D, target2D);

        //clamp to bounds
        if (Distance > mapBounds)
        {
            sprite.color = Color.yellow;
            Vector2 fromOriginToObject = this2D - target2D;
            fromOriginToObject *= mapBounds / Distance;
            transform.position = new Vector3 ((target2D + fromOriginToObject).x,transform.position.y, (target2D + fromOriginToObject).y);
        }
    }
}
