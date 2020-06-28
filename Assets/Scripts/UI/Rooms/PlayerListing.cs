using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public Player player { get; private set; }

    public void SetPlayerInfo(Player _player)
    {
        player = _player;
        int result = -1;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)player.CustomProperties["RandomNumber"];
        }
        text.text = result.ToString() + ", "+ player.NickName;
    }


}
