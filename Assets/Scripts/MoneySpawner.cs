using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class MoneySpawner : AttributesSync
{
    private Alteruna.Avatar _avatar;
    private Spawner _spawner;
    private List<string> servers = new List<string>();
    [SynchronizableField] private bool spawned = false;

    private Vector3[] positions = new Vector3[5]
    {
        new Vector3(-16.97532f, 1.642087f, 54),
        new Vector3(-2.29f, 1.623f, 49.353f),
        new Vector3(-3.579f, 1.014f, 49.353f),
        new Vector3(-0.511f, 2.274f, 49.063f),
        new Vector3(0.446f, 2.34f, 39.988f)
    };
    private Vector3[] rotation = new Vector3[5]{
        new Vector3(-90, 0, 90),
        new Vector3(-90, -90, 90),
        new Vector3(-90, -90, 90),
        new Vector3(-90, 90, 90),
        new Vector3(-90, 180, 90)
    };

    private void Awake()
    {
        _avatar = GetComponentInParent<Alteruna.Avatar>();
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

    public void SpawnMoney()
    {
        if (spawned == false)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 currentPosition = positions[i];
                Vector3 currentRotation = rotation[i];
                _spawner.Spawn(0, currentPosition, currentRotation, new Vector3(20, 10, 0.5f));
            }
            spawned = true;
        }
    }

    [SynchronizableMethod]
    void DespawnMoney(RaycastHit money)
    {
        _spawner.Despawn(money.transform.gameObject);
    }
}
