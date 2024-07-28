using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneName = "MainScene";
    // Start is called before the first frame update
    public void NewGame()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Start the Game");
    }

    public void QuitGame()
    {   
        Debug.Log("Quit the Game");
        Application.Quit();
    }
}
