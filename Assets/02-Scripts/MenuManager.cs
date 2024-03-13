using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MenuManager : MonoBehaviour
{

    [SerializeField] PlayerInput inputs;
    [SerializeField] InputActionAsset UIInput;

    [SerializeField] GameObject normalReticle;
    [SerializeField] GameObject distortReticle;

    [SerializeField] GameObject PlayerViewUI;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject Credits;
    [SerializeField] TMP_Text score;
    [SerializeField] GameData data;

    bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        distortReticle.SetActive(false);
        normalReticle.SetActive(true);
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            PlayerViewUI.SetActive(false);
            PauseMenu.SetActive(true);
            inputs.SwitchCurrentActionMap("UI");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void OnResume()
    {
        Debug.Log("Resume menu");
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        inputs.SwitchCurrentActionMap("Main");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
        PlayerViewUI.SetActive(true);
    }
    public void OnGameOver()
    {
        score.text = "Time: "+ Time.timeSinceLevelLoad.ToString("#.00")+"sec | Portals fed: "+data.portalsDestroyed+"/"+data.portalsCreated;
        inputs.SwitchCurrentActionMap("UI");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(GameOverDelay(2f));
    }

    IEnumerator GameOverDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerViewUI.SetActive(false);
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnOpenCredits()
    {
        GameOverMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void OnReturnToGameOver()
    {
        GameOverMenu.SetActive(true);
        Credits.SetActive(false);
    }
}
