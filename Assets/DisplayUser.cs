using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayUser : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;

    public void Awake()
    {
        display_player_name.text = InputUser.inputUser.player_name;
    }

}
