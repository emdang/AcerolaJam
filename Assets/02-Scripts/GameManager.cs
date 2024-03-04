using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    //[SerializeField] InputAction inputAction;
    public void QuitGame()
    {
        Application.Quit();
    }
}
