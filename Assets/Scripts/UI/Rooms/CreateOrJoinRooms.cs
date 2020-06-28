using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRooms : MonoBehaviour
{
    [SerializeField]
    private CreateRooms createRooms;

    private RoomsCanvasses roomsCanvasses;

    [SerializeField]
    private RoomListingsMenu roomListingsMenu;

    public void FirstInitialize(RoomsCanvasses canvasses)
    {
        roomsCanvasses = canvasses;
        createRooms.FirstInitialize(canvasses);
        roomListingsMenu.FirstInitialize(canvasses);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
