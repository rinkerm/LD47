using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void goToMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void goToMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void goToControls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void goToStory()
    {
        SceneManager.LoadScene("Story");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
