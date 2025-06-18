using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Declare the use of TMPro library
using TMPro;

public class UsernameLoad : MonoBehaviour
{
    public TMP_Text usernameDisplay;
    public TMP_Text scoreDisplay;
    public TMP_Text timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(usernameDisplay != null)
        {
            usernameDisplay.text = PlayerPrefs.GetString("Username");
        }
        if(scoreDisplay != null)
        {
            scoreDisplay.text = PlayerPrefs.GetInt("TotalScore").ToString();
        }
        if (timerDisplay != null)
        {
            timerDisplay.text = PlayerPrefs.GetFloat("TimeRemaining").ToString("0");
        }

    }


}
