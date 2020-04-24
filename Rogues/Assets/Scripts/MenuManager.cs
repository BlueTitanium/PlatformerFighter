using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart(){
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void GetInstructions(){
        SceneManager.LoadScene("Level0");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
