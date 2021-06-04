using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadInitialGame()
    {
        SceneManager.LoadScene("TutorialArea");
    }
    public void LoadStartScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void LoadDeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
