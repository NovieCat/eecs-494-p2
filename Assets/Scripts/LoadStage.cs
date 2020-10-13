using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStage : MonoBehaviour
{
    // Referenced from:
    // https://answers.unity.com/questions/836635/can-ui-buttons-load-scenes.html
    public void LoadStageByName(string stageName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(stageName);
    }
}
