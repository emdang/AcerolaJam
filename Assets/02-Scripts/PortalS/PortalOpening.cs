using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpening : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    [SerializeField] GameData data;
    [SerializeField] bool kysButton = false;
    [SerializeField] float timeAdd = 7f;
    [SerializeField] GameObject destroySFX;
    float timeAddStart;

    private void Start()
    {
        timeAddStart = timeAdd;
    }
    private void Update()
    {
        //for debugging
        if (kysButton)
        {
            KYS();
        }
        if(timeAdd>.75f)
            timeAdd = timeAddStart - (Time.time / 30);
    }
    public float GetEndDistance()
    {
        Debug.Log("End Distance: " + Vector3.Distance(this.transform.position, endPoint.position));
        return Vector3.Distance(this.transform.position, endPoint.position);
    }

    public void KYS()
    {
        data.portalsDestroyed++;
        data.timeLeft += timeAdd;
        Instantiate(destroySFX);
        Destroy(this.gameObject.transform.parent.gameObject.transform.parent.gameObject);//crying
    }


}
