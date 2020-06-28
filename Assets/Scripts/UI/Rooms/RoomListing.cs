using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        print(RoomInfo);
        text.text = RoomInfo.MaxPlayers + ", " + RoomInfo.Name;
    }

    public void OnCLickButton()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
        print("Joined Room! Room names = " + RoomInfo.Name);
    }

}
