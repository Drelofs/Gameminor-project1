using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
