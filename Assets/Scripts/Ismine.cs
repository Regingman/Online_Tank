using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ismine : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        if (photonView.IsMine)
        {
            AbstractTank a = gameObject.GetComponent<AbstractTank>();
            a.enabled = true;
            a.tag = "GameController";
        }
    }
}
