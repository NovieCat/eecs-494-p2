using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;


    private bool allowPlayerInput = true;
    private bool inEndSequence = false;
    

    // Called before start
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if (Time.timeScale == 0){
            Time.timeScale = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator EndGameEffect (GameObject player, bool won) {
        SetAllowPlayerInput(false);
        inEndSequence = true;
        player.GetComponent<PlayerSFX>().PlayEndGameSound(won);
        
        GameObject particleEffect = player.transform.Find("Particles").gameObject;

        //Lose effect
        // Fade referenced from:
        // https://answers.unity.com/questions/654836/unity2d-sprite-fade-in-and-out.html
        if (!won) {
            particleEffect.transform.rotation = Quaternion.Euler(-90, -90, -30);
            ParticleSystem.MainModule psMain = particleEffect.GetComponent<ParticleSystem>().main;
            psMain.startColor = Color.gray;
            particleEffect.SetActive(true);

            player.GetComponentInChildren<TextMesh>().color = Color.grey;  
            float alpha = player.GetComponentInChildren<SpriteRenderer>().material.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / 1f)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,0f,t));
                player.GetComponentInChildren<SpriteRenderer>().material.color = newColor;
                yield return null;
            }
        }

        //Win effect
        else {
            player.GetComponent<HasPower>().SetInvincible(true);

            particleEffect.SetActive(true);
            yield return new WaitForSeconds(1f);
            // particleEffect.transform.rotation = Quaternion.Euler(-20, -90, -30);
            // ParticleSystem.MainModule psMain = particleEffect.GetComponent<ParticleSystem>().main;
            // psMain.startColor = Color.yellow;
        }

        ReloadStage();     //TODO goto next stage or menu?
    }

    public void SetAllowPlayerInput(bool allow) {
        allowPlayerInput = allow;
    }

    public bool GetAllowPlayerInput() {
        return allowPlayerInput;
    }

    // public void SetInEndSequence(bool ending) {
    //     inEndSequence = ending;
    // }

    public bool GetInEndSequence() {
        return inEndSequence;
    }
}
