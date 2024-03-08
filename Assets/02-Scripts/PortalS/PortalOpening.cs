using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpening : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    public float GetEndDistance()
    {
        Debug.Log("End Distance: " + Vector3.Distance(this.transform.position, endPoint.position));
        return Vector3.Distance(this.transform.position, endPoint.position);
    }

    public void KYS()
    {
        Destroy(this.gameObject.transform.parent.gameObject);
    }


}
