using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI; //Need this for calling UI scripts
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform pauseScreen = null;
    bool isPaused;
    [SerializeField]
    Transform VictoryScreen = null;
    bool won;
    public Transform player;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreVict;
    public int highScore = 0;
    public String highScoreCall;
    public String currentLevelName;
    public String nextLevelEasy;
    public String nextLevelMed;
    public String nextLevelHard;
    public int easyLevelReq;
    public int mediumLevelReq;
    public int hardLevelReq;
    public bool overrideLevel;
    private float seconds = 0;

    public bool reset;
    public bool fullReset;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        pauseScreen.gameObject.SetActive(false);
        VictoryScreen.gameObject.SetActive(false);
        isPaused = false;
        won = false;
        time.SetText("Time: 300");
        score.SetText("Items: 0 / " + player.GetComponent<PlayerController>().maxPoints);
        highScore = PlayerPrefs.GetInt(highScoreCall, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused && !won)
            Pause();
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused && !won)
            UnPause();
        seconds += Time.deltaTime;
        time.SetText("Time: " + (300 - Math.Round(seconds,0)));
        score.SetText("Items: " + player.GetComponent<PlayerController>().points + " / " + player.GetComponent<PlayerController>().maxPoints);
        scoreVict.SetText("High Score: " + highScore);
        if(player.GetComponent<PlayerController>().points == player.GetComponent<PlayerController>().maxPoints)
            won = true;
        if(won)
            VictScreen();
        highScore = PlayerPrefs.GetInt(highScoreCall,0);

        if(reset){
            reset = false;
            PlayerPrefs.DeleteKey(highScoreCall);
            highScore = 0;
        }
        if(fullReset){
            fullReset = false;
            PlayerPrefs.DeleteAll();
            highScore = 0;
        }
        if(seconds >= 300f){
            Restart();
        }
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pauseScreen.gameObject.SetActive(true); //turn on the pause menu
        Time.timeScale = 0f; //pause the game
    }
    public void UnPause()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pauseScreen.gameObject.SetActive(false); //turn off pause menu
        Time.timeScale = 1f; //resume game
    }
    public void QuitToMainScreen(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(currentLevelName);
        Time.timeScale = 1f;
    }
    public void VictScreen()
    {
        VictoryScreen.gameObject.SetActive(true);
        StartCoroutine(ExecuteAfterTime(1));        
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
 
        // Code to execute after the delay
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        VictoryScreen.gameObject.SetActive(true);
        if((300 - Math.Round(seconds,0)) > PlayerPrefs.GetInt(highScoreCall,0)){
            PlayerPrefs.SetInt(highScoreCall, (int)(300 - Math.Round(seconds,0)));
        }
    }
    public void NextLevel(){
        if(overrideLevel){
            SceneManager.LoadScene(nextLevelEasy);
        } else if(seconds <= hardLevelReq){
            SceneManager.LoadScene(nextLevelHard);
        } else if(seconds <= mediumLevelReq){
            SceneManager.LoadScene(nextLevelMed);
        } else if(seconds <= easyLevelReq){
            SceneManager.LoadScene(nextLevelEasy);
        }
        Time.timeScale = 1f;
    }
}
