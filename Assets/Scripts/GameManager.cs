using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] panels;
    public GameObject rightPanel;
    public GameObject wrongPanel;

    public GameObject wrongEffect;

    void Start()
    {

        foreach (GameObject go in panels)
        {
            go.SetActive(false);
        }
        rightPanel.SetActive(false);
        wrongPanel.SetActive(false);

        int newPanel = Random.Range(0, 2);
        panels[newPanel].SetActive(true);
    }

    public void newQuestion()
    {
        SceneManager.LoadScene(0);
    }

    public void RightAnswer()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
            rightPanel.SetActive(true);
        }
    }

    public void WrongAnswer()
    {
        foreach (GameObject go in panels)
        {
            go.SetActive(false);
            wrongPanel.SetActive(true);
            wrongEffect.GetComponent<AudioSource>().Play();
        }
    }
}
