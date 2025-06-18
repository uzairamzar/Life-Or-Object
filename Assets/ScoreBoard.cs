using System.Collections;
using System.Collections.Generic;
//declare use library
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI userNameUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI timerUI;
    public int maxTime;
    public int maxScore;

    //create same class as UserRegister script
    [System.Serializable]
    public class RegisterNewJson
    {
        public string currentUser;

        public List<int> timeRemaining;
        public List<int> score;
    }

    void Start()
    {
        userNameUI.text = PlayerPrefs.GetString("Username");
        scoreUI.text = PlayerPrefs.GetInt("TotalScore").ToString() + "/" + maxScore.ToString();
        timerUI.text = ((int)PlayerPrefs.GetFloat("TimeRemaining")).ToString() + "/" + maxTime.ToString();
        //user function UpdateUserJson
        UpdateUserJson(PlayerPrefs.GetString("Username"), ((int)PlayerPrefs.GetFloat("TimeRemaining")), PlayerPrefs.GetInt("TotalScore"));
    }

    public void UpdateUserJson(string usernameCurrent, int timeR, int score)
    {
        //load user from list
        string usernameJson = File.ReadAllText(Application.persistentDataPath + "/UserData/User_" + usernameCurrent + ".json");
        RegisterNewJson saveScoreboardToUser = JsonUtility.FromJson<RegisterNewJson>(usernameJson);

        RegisterNewJson userToJson = new RegisterNewJson();

        userToJson.currentUser = usernameCurrent;
        userToJson.timeRemaining = new List<int>(saveScoreboardToUser.timeRemaining);
        userToJson.score = new List<int>(saveScoreboardToUser.score);
        userToJson.timeRemaining.Add(timeR);
        userToJson.score.Add(score);

        string createNewJson = JsonUtility.ToJson(userToJson, true);

        File.WriteAllText(Application.persistentDataPath + "/UserData/User_" + usernameCurrent + ".json", createNewJson);
        Debug.Log("User " + usernameCurrent + " Json created");
    }
}
