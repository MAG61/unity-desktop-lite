using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EsToEd : MonoBehaviour
{
    public int totale = 0;

    public GameObject questObject;
    public GameObject guessObject;

    Text question;
    Text guess;

    string[] electronx = { "1s", "2s", "2p", "3s", "3p", "4s", "3d", "4p", "5s", "4d", "5p", "6s" };
    int electron_layer = 1;

    public string electron_output = "";


    void Start()
    {
        question = questObject.GetComponent<Text>();
        guess = guessObject.GetComponent<Text>();

        totale = Random.Range(1, 46);

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
                    if (electron_remainder - 2 >= 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "2 ";
                        electron_remainder -= 2;

                    }
                    else if (electron_remainder < 2 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }

                    electron_layer += 1;
                }
                else if (electronx[electron_layer - 1][1] == 'p')
                {
                    if (electron_remainder - 6 >= 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "6 ";
                        electron_remainder -= 6;

                    }
                    else if (electron_remainder < 6 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }

                    electron_layer += 1;
                }
                else if (electronx[electron_layer - 1][1] == 'd')
                {
                    if (electron_remainder - 10 >= 0)
                    {
                        electron_output += electronx[electron_layer - 1] + "10 ";
                        electron_remainder -= 10;

                    }
                    else if (electron_remainder < 10 && electron_remainder != 0)
                    {
                        electron_output += electronx[electron_layer - 1] + electron_remainder.ToString() + " ";
                        electron_remainder = 0;
                    }

                    electron_layer += 1;
                }
            }
        }
        electron_output = electron_output.Trim(' ');
        question.text = totale.ToString();
    }

    public void Guess()
    {
        string guessStr = guess.text;
        if (guessStr[guessStr.Length -1] == ' ')
        {
            guessStr = guessStr.Trim(' ');
        }
        if (guessStr == electron_output)
        {
            GameObject.Find("MainGameManager").GetComponent<GameManager>().RightAnswer();
        }
        else
        {
            GameObject.Find("MainGameManager").GetComponent<GameManager>().WrongAnswer();
        }
    }

}
