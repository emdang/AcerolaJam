using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] GameData data;
    [SerializeField] float startTime;

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

    }
}
