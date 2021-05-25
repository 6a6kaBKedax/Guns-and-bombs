using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ReportPanel : MonoBehaviour
{

    public GameObject report;
    public InputField input;
    AdvancedCameraMove move;

    void Start()
    {
        move = GetComponent<AdvancedCameraMove>();
    }

    void Update()
    {
        if(Input.GetKeyDown("o"))
        {
            if(report.activeSelf == false)
            {
                report.SetActive(true);
                move.releaseCursor();
            }else
            {
                report.SetActive(false);
                move.lockCursor();
            }
        }
    }
    public void Button()
    {
        print("Nutton");
        if (Equals(input, "Нариман Абу") || Equals(input, "Абу Нариман"))
        {
            SceneManager.LoadScene(3);
        }
        else 
        {
            SceneManager.LoadScene(4);
        }
    }
}
