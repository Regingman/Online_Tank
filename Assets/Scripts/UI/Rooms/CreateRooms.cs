using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text roomName;

    private RoomsCanvasses roomsCanvasses;

    public void FirstInitialize(RoomsCanvasses canvasses)
    {
        roomsCanvasses = canvasses;
    }

    public void OnClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            print("IsConnected");
            return;
        }
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, options, TypedLobby.Default);

    }

    public override void OnCreatedRoom()
    {
        print("Room Created, names: " + roomName.text);
        roomsCanvasses._CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Room Created failed");
    }
}
