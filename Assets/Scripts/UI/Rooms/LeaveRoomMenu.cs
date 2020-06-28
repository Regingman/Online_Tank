using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvasses roomsCanvasses;

    public void FirstInitialize(RoomsCanvasses rooms)
    {
        roomsCanvasses = rooms;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.LeaveRoom(true);
        roomsCanvasses._CurrentRoomCanvas.Hide();
        print("Leaves Rooms!");
    }
}
