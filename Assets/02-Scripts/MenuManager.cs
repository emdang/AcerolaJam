using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PlayerInput inputs;
    [SerializeField] InputActionAsset UIInput;

    [SerializeField] GameObject normalReticle;
    [SerializeField] GameObject distortReticle;

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        distortReticle.SetActive(false);
        normalReticle.SetActive(true);
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPause()
    {
        PauseMenu.SetActive(true);
        inputs.SwitchCurrentActionMap("UI");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ClosePause()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
