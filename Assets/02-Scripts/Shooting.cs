using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float shootVelocity;
    [SerializeField] Camera cam;
    [SerializeField] float coolDown;
    float cooling;

    [SerializeField] bool shootEnabled = true;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cooling = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootEnabled)
            cooling -= Time.deltaTime;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!shootEnabled || cooling >0)
            return;
        Vector3 spawnPosition = this.transform.position + cam.transform.forward;
        GameObject newProjectile = Instantiate(projectile, spawnPosition, cam.transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce((cam.transform.forward)*shootVelocity,ForceMode.VelocityChange);
        cooling = coolDown;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        DisableShooting();
    }

    public void DisableShooting()
    {
        shootEnabled = false;
    }

    public void EnableShooting()
    {
        shootEnabled = true;
    }
}
