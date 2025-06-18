using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Declare the use of TMPro library
using TMPro;
using Unity.Collections;
using System.Xml.Linq;

public class UsernameInput : MonoBehaviour
{
    public SceneControl sceneScript;
    public GameObject errorPanel;

    public string errorAudio;
    public string correctAudio;
    public string sceneToLoad;

    //Create a function to save username in session data using the TMPro inputfield as parameter
    public void UsernameSave(TMP_InputField usernameInputField)
    {
        if (!string.IsNullOrWhiteSpace(usernameInputField.text))
        {
            //Save the text component from inputfield into a session data named Username
            PlayerPrefs.SetString("Username", usernameInputField.text);
            
            if (GameObject.Find(correctAudio) != null) GameObject.Find(correctAudio).GetComponent<AudioSource>().Play();
            sceneScript.LoadCustomScene(sceneToLoad);
        }
        else
        {
            if (GameObject.Find(errorAudio) != null) GameObject.Find(errorAudio).GetComponent<AudioSource>().Play();
            errorPanel.SetActive(true);
        }

    }
}
