﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;

    private RoomsCanvasses roomsCanvasses;

    private List<RoomListing> listings = new List<RoomListing>();

    public void FirstInitialize(RoomsCanvasses canvasses)
    {
        roomsCanvasses = canvasses;
    }

    public override void OnJoinedRoom()
    {
        roomsCanvasses._CurrentRoomCanvas.Show();
        content.DestroyChildren();
        listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {

                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }

            }
            else
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(roomListing, content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        listings.Add(listing);
                    }
                }
                else
                {
                    //ModifyListing
                    //listings[index].downEver;
                }
            }

        }
    }
}
