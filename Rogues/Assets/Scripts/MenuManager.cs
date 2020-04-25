using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Transform levelSelect = null;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        levelSelect.localScale = new Vector3(0,0,0);
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
    public void LevelSelect(){
        levelSelect.localScale = new Vector3(1,1,1);
    }
    public void ChooseLevel1(){
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void ChooseLevel2e(){
        SceneManager.LoadScene("Level2E");
        Time.timeScale = 1f;
    }
    public void ChooseLevel2m(){
        SceneManager.LoadScene("Level2M");
        Time.timeScale = 1f;
    }
    public void ChooseLevel2h(){
        SceneManager.LoadScene("Level2H");
        Time.timeScale = 1f;
    }
    public void ChooseLevel3e(){
        SceneManager.LoadScene("Level3E");
        Time.timeScale = 1f;
    }
    public void ChooseLevel3m(){
        SceneManager.LoadScene("Level3M");
        Time.timeScale = 1f;
    }
    public void ChooseLevel3h(){
        SceneManager.LoadScene("Level3H");
        Time.timeScale = 1f;
    }
    public void ChooseLevel4e(){
        SceneManager.LoadScene("Level4E");
        Time.timeScale = 1f;
    }
    public void ChooseLevel4m(){
        SceneManager.LoadScene("Level4M");
        Time.timeScale = 1f;
    }
    public void ChooseLevel4h(){
        SceneManager.LoadScene("Level4H");
        Time.timeScale = 1f;
    }
    public void GoBack(){
        levelSelect.localScale = new Vector3(0,0,0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
