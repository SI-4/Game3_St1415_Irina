using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviourPunCallbacks
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider healthBar;
    private PhotonView pv;

    public void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    void Start()
    {
        health = maxHealth;
        healthBar.value = health;
    }

    public void TakeDamage(int value)
    {
        pv.RPC("UpdateHealth", RpcTarget.All, value);
    }

    [PunRPC]
    public void UpdateHealth(int value)
    {
        health -= value;

        if (health <= 0)
        {
            health = maxHealth;
            transform.GetComponent<PlayerControler>().Respawn();
        }
        healthBar.value = health;
    }

    void Update()
    {
        
    }
}
