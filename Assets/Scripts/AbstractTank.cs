using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class AbstractTank : MonoBehaviourPunCallbacks
{
    public float speed = 10f;
    public float damage = 10f;
    public float health = 100;
    public GameObject patron;
    private bool flag = false;

    private Vector2 direction = Vector2.up;
    private float timer = 1f;

    public enum Direction
    {
        right,
        left,
        up,
        down
    }

    private Direction newDirection;

    public void Update()
    {
        GetInput();
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(direction.x, direction.y, 0);
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction.y += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 90);
            newDirection = Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction.y -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            newDirection = Direction.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction.x -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            newDirection = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction.x += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            newDirection = Direction.right;
        }

        if (flag)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1f;
                flag = false;
            }
        }

        if (Input.GetKey(KeyCode.Space) && !flag)
        {
            PhotonView pView = GetComponent<PhotonView>();
            pView.RPC("Fire", RpcTarget.All);
        }
    }

    [PunRPC]
    public void CollectHealth()
    {
        health -= 10f;
        if (health <= 0)
        {
            Destroy(gameObject);
            print("you Died");
        }
    }

    [PunRPC]
    public void Fire()
    {

        flag = true;
        GameObject patr = Instantiate(patron, transform);
        patr.transform.parent = null;
        patr.gameObject.SetActive(true);
        Patron a = patr.GetComponent<Patron>();
        a.target = transform.position;
        switch (newDirection)
        {
            case Direction.down: a.target.y = transform.position.y - 600f; break;
            case Direction.up: a.target.y = transform.position.y + 600f; break;
            case Direction.left: a.target.x = transform.position.x - 600f; break;
            case Direction.right: a.target.x = transform.position.x + 600f; break;
        }
    }
}
