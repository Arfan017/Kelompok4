using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerName : MonoBehaviour
{
    public static PlayerName playerName;
    public string NamePlayer;
    [SerializeField] TMP_InputField inputField;
    public TextMeshProUGUI displayPlayerName;

    private void Awake() 
    {
        if(playerName == null)
        {
            playerName = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        displayPlayerName.text = PlayerName.playerName.NamePlayer;
    }

    public void SetPlayerName()
    {
        NamePlayer = inputField.text;

        SceneManager.LoadSceneAsync("MapGame1");
    }
}
