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
    MoneySpawner gmScript;
    private int moneyToAdd;

    void Start()
    {
        if (!avatar.IsMe) return;

        uiScript = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
        gmScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MoneySpawner>();
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
            if (hit.transform.gameObject.name.Contains("Dollar"))
            {
                moneyToAdd = 100;
                gmScript.BroadcastRemoteMethod("DespawnMoney", hit);
                uiScript.BroadcastRemoteMethod("UpdateMoney", moneyToAdd);
            }
            else if (hit.transform.gameObject.name.Contains("Safe"))
            {
                GameObject.FindGameObjectWithTag("FingerprintUI").transform.Find("FingerprintPanel").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("FingerprintUI").GetComponentInChildren<Fingerprint>().StartFingerprint();
                transform.parent.GetComponentInChildren<MouseLook>().FingerPrintToggle();
            }
            else if (hit.transform.gameObject.name.Contains("Car"))
            {
                Cursor.lockState = CursorLockMode.None;
                uiScript.BroadcastRemoteMethod("Escape");
            }
        }
    }
}
