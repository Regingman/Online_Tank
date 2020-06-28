using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Photon;
using Photon.Chat;
public class Patron : MonoBehaviourPunCallbacks
{
    public Vector2 target;

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet")
        {
            if (collision.tag == "Player")
            {
                AbstractTank abstractTank = collision.gameObject.GetComponent<AbstractTank>();

                //PhotonView pView = abstractTank.GetComponent<PhotonView>();
                //pView.RPC("CollectHealth", RpcTarget.All);
                abstractTank.CollectHealth();
            }
            Destroy(gameObject, 0.05f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Bullet")
        {
            Destroy(gameObject, 0.05f);
        }
    }
}
