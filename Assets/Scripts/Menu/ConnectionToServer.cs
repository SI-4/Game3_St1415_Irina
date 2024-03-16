using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class ConnectionToServer : MonoBehaviourPunCallbacks
{
    public static ConnectionToServer Instance;
    [SerializeField] private TMP_InputField inputRoomName;
    [SerializeField] private TMP_Text roomName;

    [SerializeField] private PlayerNameItem playerNameItemPb;
    [SerializeField] private Transform playerNameItemPos;

    [SerializeField] private RoomNameItem roomNameItemPb;
    [SerializeField] private Transform roomNameItemPos;
    private Dictionary<string, RoomNameItem> cachedRoomList = new Dictionary<string, RoomNameItem>();

    [SerializeField] private GameObject startGameButton;

    private void Awake()
    {
        Instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public void CreateNewRoom()
    {
        if(string.IsNullOrEmpty(inputRoomName.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(inputRoomName.text);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinedRoom()
    {
        WindowsManager.layout.OpenWindow("GameRoom");
        roomName.text = PhotonNetwork.CurrentRoom.Name;

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);



        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < playerNameItemPos.childCount; i++)
        {
            Destroy(playerNameItemPos.GetChild(i));
        }
        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerNameItemPb,playerNameItemPos).SetUp(players[i]);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
            {
                if (cachedRoomList.ContainsKey(info.Name))
                {
                    Destroy(cachedRoomList[info.Name].gameObject);
                    cachedRoomList.Remove(info.Name);
                }
            }
            else
            {
                if (!cachedRoomList.ContainsKey(info.Name))
                {
                    cachedRoomList[info.Name] = Instantiate(roomNameItemPb, roomNameItemPos);
                    cachedRoomList[info.Name].SetUp(info);
                }
            }
        }
    }

    public void JoinRoom(RoomInfo roomInfo)
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerNameItemPb, playerNameItemPos).SetUp(newPlayer);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        WindowsManager.layout.OpenWindow("MainMenu");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.AutomaticallySyncScene = true;

    }
    public override void OnJoinedLobby()
    {
        WindowsManager.layout.OpenWindow("MainMenu");
        Debug.Log("Connected");
    }
    public void StartGameLevel(int levelIndex)
    {
        PhotonNetwork.LoadLevel(levelIndex);
    }
    public void ConnectToRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

}
