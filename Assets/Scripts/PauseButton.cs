using UnityEngine;
using UnityEngine.UI;  
public class PauseButton : MonoBehaviour {
    GameObject pauseMenu;

    void Start() {
        GetComponent<Button>().onClick.AddListener(TogglePause);
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        pauseMenu.SetActive(false);
    }
    public void TogglePause() {
        GameControl.instance.SetAllowPlayerInput(!GameControl.instance.GetAllowPlayerInput());   
        // Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        } else if (Time.timeScale == 0){
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeBtn() {
        if (Time.timeScale == 0){
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void RetryBtn() {
        GameControl.instance.ReloadStage();
    }

    public void ReturnBtn() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
