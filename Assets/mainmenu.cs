using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainmenu : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreText;
    void Start(){
        if (!PlayerPrefs.HasKey("highScore"))
        {
          PlayerPrefs.SetInt("highScore", 0);
        }
        else
        {
            highscoreText.text="High Score: "+PlayerPrefs.GetInt("highScore");
        }
    }
   public void playgame()
    {
        SceneManager.LoadScene("main");

    }
    public void retry(){
        SceneManager.LoadScene("main");
    }
    public void mm(){
        SceneManager.LoadScene("main trial");
    }
    public void exit(){
        Application.Quit();
    }
}
