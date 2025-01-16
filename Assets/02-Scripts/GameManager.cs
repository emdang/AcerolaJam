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
    [SerializeField] GameObject gameOverClip;
    bool gameOver = false;
    [SerializeField] Animator motherAnimator;

    private void Awake()
    {
        data.gameOver = false;
        data.portalsCreated = 0;
        data.portalsDestroyed = 0;
        data.timeLeft = startTime;
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (data.timeLeft <= 1)//out of time
            {
                GameOver();
                gameOver = true;
                return;
            }
            DecreaseTime(Time.deltaTime);
        }
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
        Instantiate(gameOverClip);
        motherAnimator.SetTrigger("GameOver");
        data.gameOver = true;
    }
}
