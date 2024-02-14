using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button exit;
    [SerializeField] private Button credits;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private Button backCredits;

    void Start()
    {
        play.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        backCredits.gameObject.SetActive(false);
        creditsPanel.gameObject.SetActive(false);
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Credits() //this toggles the credits panel
    {
        if(creditsPanel.gameObject.activeSelf)
        {
            play.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
            credits.gameObject.SetActive(true);
            creditsPanel.gameObject.SetActive(false);
            backCredits.gameObject.SetActive(false);
        }
        else
        {
            creditsPanel.gameObject.SetActive(true);
            backCredits.gameObject.SetActive(true);
            play.gameObject.SetActive(false);
            exit.gameObject.SetActive(false);
            credits.gameObject.SetActive(false);
        }
    }
}
