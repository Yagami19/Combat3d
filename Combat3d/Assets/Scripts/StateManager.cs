using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public GameObject pause;
    public bool isPaused;
    public GameObject Player;
    public GameObject Opp;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        isPaused = false;
        pause.SetActive(false);

         Player = GameObject.Find("SpherePlayer");
        Opp = GameObject.Find("SphereOpponent");
    }

    void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (isPaused == false)
            {         
                PauseGame();
                isPaused = true;
            }
            else
            {
                if (isPaused == true)
                {
                    ContinueGame();
                }
            }
        }

    }



    private void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        Player.GetComponent<PlayerMove>().enabled = false;
        Opp.GetComponent<OpponentMove>().enabled = false;
        pause.SetActive(true);
        isPaused = true;
        //Disable scripts that still work while timescale is set to 0
    }


    public void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Player.GetComponent<PlayerMove>().enabled = true;
        Opp.GetComponent<OpponentMove>().enabled = true;
        pause.SetActive(false);
        isPaused = false;
    }


    public void MainMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}




