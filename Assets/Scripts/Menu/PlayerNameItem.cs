using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class PlayerNameItem : MonoBehaviourPunCallbacks 
{
    [SerializeField] private TMP_Text playerName;
    private Player player;
    // Start is called before the first frame update
    
    public void SetUp(Player player)
    {
        this.player = player;
        playerName.text = this.player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
