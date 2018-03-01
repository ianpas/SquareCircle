using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartLevelCircle()
    {
        SceneManager.LoadScene("Level Circle");
    }

    public void StartLevelSquare()
    {
        SceneManager.LoadScene("Level Square");
    }

    public void DisplayGameRules()
    {
        SceneManager.LoadScene("Game Rules");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
