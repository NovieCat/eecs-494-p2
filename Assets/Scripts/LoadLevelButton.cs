using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelButton : MonoBehaviour
{
    // public string levelName;

    // Referenced from:
    // https://answers.unity.com/questions/836635/can-ui-buttons-load-scenes.html
    public void NextLevelButton(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
