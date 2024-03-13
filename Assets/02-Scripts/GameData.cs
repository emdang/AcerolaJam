using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public float timeLeft;
    public int portalsCreated;
    public int portalsDestroyed;
    public bool gameOver;
}
