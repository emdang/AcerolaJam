using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] GameData data;
    [SerializeField] float startTime;
    [SerializeField] PlayerInput inputs;

    private void Start()
    {
        data.portalsCreated = 0;
        data.portalsDestroyed = 0;
        data.timeLeft = startTime;
    }

    private void Update()
    {
        if (data.timeLeft <= 0)//out of time
        {
            GameOver();
            return;
        }
        DecreaseTime(Time.deltaTime);
    }
    public void DecreaseTime(float amount)
    {
        data.timeLeft -= amount;
    }
    public void IncreaseTime(float amount)
    {
        data.timeLeft += amount;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        inputs.SwitchCurrentActionMap("Main");
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnPortalSpawn()
    {
        Debug.Log("portal spawned called");
        data.portalsCreated++;
    }

    public void OnPortalDestroy()
    {
        data.portalsDestroyed++;
    }

    public void GameOver()
    {
        BroadcastMessage("OnGameOver");
    }
}
