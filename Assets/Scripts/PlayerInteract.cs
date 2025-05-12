using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using System;

public class PlayerInteract : AttributesSync
{
    public Alteruna.Avatar avatar;
    public int range = 10;
    [SerializeField] private LayerMask interactableLayer;
    PlayerUI uiScript;
    private int moneyToAdd;

    void Start()
    {
        if (!avatar.IsMe) return;

        uiScript = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
    }

    void Update()
    {
        if (!avatar.IsMe) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && Cursor.lockState == CursorLockMode.Locked)
        {
            Interact();
        }
    }
    
    void Interact()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit,
        range, interactableLayer))
        {
            moneyToAdd = 100;
            BroadcastRemoteMethod("CollectMoney", hit);
            uiScript.BroadcastRemoteMethod("UpdateMoney", moneyToAdd);
        }
    }

    [SynchronizableMethod]
    public void CollectMoney(RaycastHit hit)
    {
        Destroy(hit.transform.gameObject);
    }
}
