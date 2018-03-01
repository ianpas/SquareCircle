using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void EndGame()
    {
        if (!m_GameOver)
        {
            m_GameOver = true;

            m_Player.StopRunning();
            m_Player.enabled = false;

            m_Camera.Promote();

            Debug.Log("game is over");
            Debug.Log(FindObjectOfType<FinalFootprint>().m_Cos);

            //Restart();
            //m_LevelCompleteUI.SetActive(true);
        }
    }

    //private void Restart()
    //{
    //    SceneManager.LoadScene("Level Circle");
    //}

    private void Update()
    {
        if (m_GameOver)
        {
            m_MarksManager.Show();

            if (m_Camera.transform.position.y > 50)
            {
                m_ScoreManager.ShowScore((int)(FindObjectOfType<FinalFootprint>().m_Cos * 100));
                m_MainMenuManager.ShowButton();

                if (m_RestartCircleManager)
                {
                    m_RestartCircleManager.ShowButton();
                }

                if (m_RestartSquareManager)
                {
                    m_RestartSquareManager.ShowButton();
                }
            }
        }
        else
        {
            if (Time.timeSinceLevelLoad > 4.5f)
            {
                Debug.Log(Time.timeSinceLevelLoad);
                m_MarksManager.Hide();
            }
        }
    }

    public SampleAnimation m_Player;
    public CameraFollow m_Camera;

    public MarksManager m_MarksManager;
    public ScoreManager m_ScoreManager;
    public MainMenuManager m_MainMenuManager;
    public RestartCircleManager m_RestartCircleManager;
    public RestartSquareManager m_RestartSquareManager;

    private bool m_GameOver = false;
    private float m_Time = 0;
}
