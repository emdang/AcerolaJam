using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDataUpdate : MonoBehaviour
{
    [SerializeField] GameData data;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Hello World";
        scoreText.text = "hewwo";
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        updateScore();
    }



    void updateTime()
    {
        timerText.text = "Timer:"+Mathf.FloorToInt(data.timeLeft);
    }
    void updateScore()
    {
        scoreText.text = "Portals:" + data.portalsDestroyed + "/" + data.portalsCreated;
    }
}
