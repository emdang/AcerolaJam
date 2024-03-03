using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool hitPortal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Opening")
        {
            Debug.Log("we in");
            hitPortal = true;
            this.gameObject.layer = 11;
        }
        if(other.tag == "End")
        {
            if (!hitPortal)
                return;
            Debug.Log("esplode");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
