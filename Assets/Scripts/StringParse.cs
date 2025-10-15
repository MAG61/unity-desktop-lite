using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StringParse : MonoBehaviour
{
    string e = "1s2,2s2,2p6,3s2";
    public int totale = 0;
    public Sprite image;

    Text question;
    Text guess;
    public GameObject questPanel;
    public GameObject helalPanel;
    public GameObject malPanel;

    public GameObject[] slots;


    // 1s, 2s, 2p, 3s, 3p, 4s, 3d, 4p, 5s, 4d, 5p, 6s, 4f, 5d, 6p, 7s, 5f, 6d, 7p, 8s, 5g, 6f, 7d, 8p, 9s

    string[] electronx = { "1s", "2s", "2p", "3s", "3p", "4s", "3d", "4p", "5s", "4d", "5p", "6s" };
    int electron_layer = 1;

    // Dictionary<string, int>

    Dictionary<string, int> AtomEve = new Dictionary<string, int> {
        {"H", 1},{"He",2},{"Li",3},{"Be",4},{"B",5},
        {"C", 6},{"N",7},{"O",8},{"F",9},{"Ne",10},
        {"Na", 11},{"Mg",12},{"Al",13},{"Si",14},{"P",15},
        {"S", 16},{"Cl",17},{"Ar",18},{"K",19},{"Ca",20}
    };
    string[] AtomEveAll = { "H","He","Li","Be","B","C","N","O","F","Ne","Na","Mg","Al","Si","P","S","Cl","Ar","K","Ca"};
    string electron_output = "";


    void Start()
    {
        int AtomEveIndex = Random.Range(0,AtomEveAll.Length);
        int AtomEveQ = AtomEve[AtomEveAll[AtomEveIndex]];   
        totale = AtomEveQ;

        Debug.Log(AtomEveQ.ToString());

        for (int i = 0; i < totale; i++)
        {
            slots[i].SetActive(true);
            slots[i].GetComponent<Image>().sprite = GameObject.Find("Image").GetComponent<Image>().sprite;
        }

        question = GameObject.Find("QuestionText").GetComponent<Text>();
        guess = GameObject.Find("GuessText").GetComponent<Text>();

        int electron_remainder = totale;
        if (totale == 29)
        {
            electron_output = "1s2 2s2 2p6 3s2 3p6 4s1 3d10 ";
        }
        else if (totale == 24)
        {
            electron_output = "1s2 2s2 2p6 3s2 3p6 4s1 3d5 ";
        }
        else
        {
            for (int e = 0; e < electronx.Length; e++)
            {
                if (electron_remainder == 0)
                {
                    break;
                }
                if (electronx[electron_layer - 1][1] == 's')
                {
                    if (electron_remainder - 2 > 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "2 ";
                        electron_remainder -= 2;

                    }
                    else if (electron_remainder < 2 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }
                    else if (electron_remainder == 0)
                    {

                    }

                    electron_layer += 1;
                }
                else if (electronx[electron_layer - 1][1] == 'p')
                {
                    if (electron_remainder - 6 > 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "6 ";
                        electron_remainder -= 6;

                    }
                    else if (electron_remainder < 6 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }
                    else if (electron_remainder == 0)
                    {

                    }

                    electron_layer += 1;
                }
                else if (electronx[electron_layer - 1][1] == 'd')
                {
                    if (electron_remainder - 10 > 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "10 ";
                        electron_remainder -= 10;

                    }
                    else if (electron_remainder < 10 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }
                    else if (electron_remainder == 0)
                    {

                    }

                    electron_layer += 1;
                }
            }
        }
        electron_output = electron_output.Trim(' ');
        question.text = electron_output;

        //string[] e1 = e.Split(' ');
        //for (int i = 0; i < e1.Length; i++)
        //    Debug.Log(e1[i]);
    }

    public void Guess()
    {
        if (guess.text == totale.ToString())
        {
            questPanel.SetActive(false);
            helalPanel.SetActive(true);
            StartCoroutine(quest());
        }
        else
        {
            questPanel.SetActive(false);
            malPanel.SetActive(true);
            StartCoroutine(quest());
        }
    }

    IEnumerator quest()
    {
        yield return new WaitForSeconds(2);
        questPanel.SetActive(true);
        helalPanel.SetActive(false);
        malPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
