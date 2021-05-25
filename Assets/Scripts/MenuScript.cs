using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NewGamePressed() 
    {
        SceneManager.LoadScene(2);
    }
    public void VihodPressed()
    {
        print("Quit");
        Application.Quit();
    }
}
