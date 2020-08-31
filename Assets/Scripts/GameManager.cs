using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CreditClose()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ManualClose()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Manual()
    {
        SceneManager.LoadScene("Manual");
    }

   

}
