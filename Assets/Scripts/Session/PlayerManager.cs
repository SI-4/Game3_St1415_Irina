using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private PhotonView pnView;

    private void Awake()
    {
        pnView = GetComponent<PhotonView>();
    }

    void Start()
    {
        if(pnView.IsMine)
        {
            CreateController();
        }
    }
    private void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("PlayerController"), Vector3.zero, Quaternion.identity);

    }
   
}
