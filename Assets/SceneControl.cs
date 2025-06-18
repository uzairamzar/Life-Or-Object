using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Declare usage of SceneManagement library
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public void LoadCustomScene(string customScene) //any string value set in this parameter will be inherited
    {
        //load scene with the specific name using the value inherited from parameter
        SceneManager.LoadScene(customScene);
    }

    public void ExitGame() //exit game only when published
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void LoadSFX(string sfxName)
    {
        if(GameObject.Find(sfxName) != null)
        {
            GameObject.Find(sfxName).GetComponent<AudioSource>().Play();
        }

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
