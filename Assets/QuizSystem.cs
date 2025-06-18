using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class QuizSystem : MonoBehaviour
{
    //only set this one to 0 if you want to start the game with 0 score at current scene
    public int scoreCount = 0;
    public string correctSFX;
    public string wrongSFX;


    public void changeScore(int changedScore)
    {
        scoreCount += changedScore;
        PlayerPrefs.SetInt("TotalScore", scoreCount);
    }

    public void correctAnswer()
    {
        scoreCount += 10;
        PlayerPrefs.SetInt("TotalScore", scoreCount);

        if (GameObject.Find(correctSFX) != null)
        {
            GameObject.Find(correctSFX).GetComponent<AudioSource>().Play();
        }
    }

    public void wrongAnswer()
    {
        PlayerPrefs.SetInt("TotalScore", scoreCount);

        if (GameObject.Find(wrongSFX) != null)
        {
            GameObject.Find(wrongSFX).GetComponent<AudioSource>().Play();
        }
    }
}
