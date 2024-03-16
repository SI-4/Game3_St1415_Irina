using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RoomNameItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    private RoomInfo info;

    internal void SetUp(RoomInfo info)
    {
        this.info = info;
        roomName.text = info.Name;
    }

    public void OnClick()
    {
        ConnectionToServer.Instance.JoinRoom(this.info);
    }
}
