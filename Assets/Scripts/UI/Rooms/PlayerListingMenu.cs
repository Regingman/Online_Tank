using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing playerListing;
    [SerializeField]
    private Text readyUpText;

    private List<PlayerListing> listings = new List<PlayerListing>();

    private RoomsCanvasses roomsCanvasses;
    private bool ready = false ;

    public override void OnEnable()
    {
        base.OnEnable();
        //SetReadyUp(false);
        GetCurrentRoomPlayer();
    }

    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < listings.Count; i++)
        {
            Destroy(listings[i].gameObject);
        }
        listings.Clear();
    }

    private void SetReadyUp(bool state)
    {
        ready = state;
        if (ready)
        {
            readyUpText.text = "R";
        }
        else
        {
            readyUpText.text = "N";
        }
    }

    public void OnClick_ReadyUp()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            SetReadyUp(!ready);
            base.photonView.RPC("RPC_ChangeReadyState", RpcTarget.MasterClient, PhotonNetwork.LocalPlayer, ready);
            //PhotonNetwork.RemoveRPCs()
        }
    }

    [PunRPC]
    private void RPC_ChangeReadyState(Player player, bool _ready)
    {
        int index = listings.FindIndex(x => x.player == player);
        if (index != -1)
        {
            listings[index].Ready = ready;
        }
    }


    public void GetCurrentRoomPlayer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }

        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    public void FirstInitialize(RoomsCanvasses _roomsCanvasses)
    {
        roomsCanvasses = _roomsCanvasses;
        listings.Clear();
    }



    private void AddPlayerListing(Player player)
    {
        int index = listings.FindIndex(x => x.player == player);
        if (index == -1)
        {
            PlayerListing listing = Instantiate(playerListing, content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                listings.Add(listing);
            }
        }
        else
        {
            listings[index].SetPlayerInfo(player);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    }

    public void OnClick_StartButton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }
}
