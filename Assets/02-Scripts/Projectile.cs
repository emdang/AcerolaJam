using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] bool hitPortal = false;
    float hitPortalStart = -1;
    float lifeTime = 5f;
    Vector3 impactPoint;
    float endPointDistance;
    [SerializeField] LayerMask newLayers;
    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPortal)
        {
            if (!paused)
            {
                float lerpValue = Vector3.Distance(impactPoint, this.transform.position) / endPointDistance;

                this.transform.localScale = new Vector3(lerpValue, lerpValue, lerpValue);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.name+" "+collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Opening")
        {
            Debug.Log("we in");
            hitPortal = true;
            //this.gameObject.layer = 10;
            GetComponent<Collider>().excludeLayers = newLayers;
            impactPoint = this.transform.position;
            endPointDistance = other.GetComponent<PortalOpening>().GetEndDistance(); 
        }
        if(other.tag == "End")
        {
            if (!hitPortal)
                return;
            Debug.Log("esplode");
            this.gameObject.transform.parent = other.gameObject.transform;
            other.gameObject.SendMessageUpwards("KYS");
            //Destroy(this.gameObject);
        }
    }


}
