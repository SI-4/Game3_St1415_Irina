using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;


public class SetPlayerName : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField nickNameField;

    public override void OnConnectedToMaster()
    {
        LoadNickName();
    }

    private void LoadNickName()
    {
        string playerName = PlayerPrefs.GetString("NickName");
        if(string.IsNullOrEmpty(playerName))
        {
            playerName = "Player" + Random.Range(0,999);
        }
        PhotonNetwork.NickName = playerName;
        nickNameField.text = playerName;
    }

    public void ChangeNickName()
    {
        PlayerPrefs.SetString("NickName", nickNameField.text);
        LoadNickName();
    }
}
