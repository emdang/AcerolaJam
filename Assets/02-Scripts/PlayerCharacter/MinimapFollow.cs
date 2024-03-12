using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] float mapBounds = 5f;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("MinimapCam").transform;

    }

    private void Update()
    {
        pos = transform.parent.transform.position;
        pos.y = transform.position.y;
        transform.position = pos;
        //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // Distance from the gameObject to Minimap
        Vector2 this2D = new Vector2(transform.position.x, transform.position.z);
        Vector2 target2D = new Vector2(targetTransform.position.x, targetTransform.position.z);
        float Distance = Vector2.Distance(this2D, target2D);

        // If the Distance is less than MinimapSize, it is within the Minimap view and we don't need to do anything
        // But if the Distance is greater than the MinimapSize, then do this
        if (Distance > mapBounds)
        {
            // Gameobject - Minimap
            Vector2 fromOriginToObject = this2D - target2D;

            // Multiply by MinimapSize and Divide by Distance
            fromOriginToObject *= mapBounds / Distance;

            // Minimap + above calculation
            transform.position = new Vector3 ((target2D + fromOriginToObject).x,transform.position.y, (target2D + fromOriginToObject).y);
        }
    }
}
