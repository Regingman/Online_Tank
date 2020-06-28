using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvasses : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRooms createOrJoinRooms;
    [SerializeField]
    private CurrentRoomCanvas currentRoomCanvas;

    public CreateOrJoinRooms _CreateOrJoinRooms { get { return createOrJoinRooms; } }
    public CurrentRoomCanvas _CurrentRoomCanvas { get { return currentRoomCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }


    public void FirstInitialize()
    {
        createOrJoinRooms.FirstInitialize(this);
        currentRoomCanvas.FirstInitialize(this); 
    }
}
