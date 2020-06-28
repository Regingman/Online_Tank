using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager self;
    public enum Groups
    {
        GroupA,
        GroupB
    }

    public Groups group;

    private void Awake()
    {
        if (self == null)
        {
            self = this;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
            PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.SendRate = 60;
            print("Connection true! \nYour NickName =" + PhotonNetwork.LocalPlayer.NickName);

        }
        else
        {
            Destroy(self);
        }

    }

    public override void OnConnectedToMaster()
    {

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        //PhotonNetwork.JoinRandomRoom();
    }

    /* public override void OnJoinedRoom()
     {
         print("Join Room, create PlayerTank");
         System.Random rnd = new System.Random();
         int value = rnd.Next(-4, 4);
       //  PhotonNetwork.Instantiate("Player", new Vector3(0 + value, 0 + value, 0), Quaternion.identity, 0);

     }*/

    /*public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("Random room has fallen, create new room");
        //PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }*/

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server: " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
    }
}
