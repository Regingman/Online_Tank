using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu playerListingMenu;
    [SerializeField]
    private LeaveRoomMenu leaveRoomMenu;

    private RoomsCanvasses roomsCanvasses;

    public void FirstInitialize(RoomsCanvasses canvasses)
    {
        roomsCanvasses = canvasses;
        playerListingMenu.FirstInitialize(canvasses);
        leaveRoomMenu.FirstInitialize(canvasses);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
