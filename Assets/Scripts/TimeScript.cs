using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimeScript : MonoBehaviour
{
    public GameObject Timer;
    public GameObject InfoItemUI;
    public GameObject InfoItemTextUI;

    public AdvancedCameraMove move;

    bool pauseUIstatus = false;
    // Start is called before the first frame update
    //Ray ray = new Ray();
    public float timeLeft { get; set; } = 3600f;
    void Start()
    {
        timeLeft = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.GetComponent<Text>().text = SecondsToDate(timeLeft);
        Pause();
        if (pauseUIstatus == false)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                print("End");
                //LoadScene(2);
            }
        }
    }

    string SecondsToDate(float seconds)
    {
        int roundedSeconds = Convert.ToInt32(seconds);
        int hours = roundedSeconds / 3600;
        roundedSeconds -= hours * 3600;

        int minutes = roundedSeconds / 60;
        roundedSeconds -= minutes * 60;

        return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, roundedSeconds);
    }

    bool Pause()
    {
        if (pauseUIstatus == false && Input.GetKeyDown(KeyCode.Escape))
        {
            InfoItemUI.SetActive(true);
            InfoItemTextUI.GetComponent<Text>().text = "Нажмите Escape - что бы продолжить" + "\n" + "Нажмите Q - что бы выйти в меню"; 
            pauseUIstatus = true;
            move.releaseCursor();
            return true;
        }
        else if (pauseUIstatus == true && Input.GetKeyDown(KeyCode.Escape))
        {
            InfoItemUI.SetActive(false);
            InfoItemTextUI.GetComponent<Text>().text = "";
            move.lockCursor();
            pauseUIstatus = false;
        }
        if (pauseUIstatus == true && Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);
        }
        return false;
    }
}
