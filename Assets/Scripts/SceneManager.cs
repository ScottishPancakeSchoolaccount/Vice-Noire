using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    //This is for the start button 

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void DeathScreen()
    {
        //Here will be the death screen
    }
}

