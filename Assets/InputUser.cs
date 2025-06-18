using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputUser : MonoBehaviour
{
    public static InputUser inputUser;
    public TMP_InputField inputField;

    public string player_name;

    private void Awake()
    {
        if (inputUser == null)
        {
            inputUser = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;

        SceneManager.LoadSceneAsync("Quiz");
    }

}
