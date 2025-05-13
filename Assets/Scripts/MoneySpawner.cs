using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;
using Unity.VisualScripting;

public class MoneySpawner : AttributesSync
{
    private Alteruna.Avatar _avatar;
    private bool hasSpawned = false;
    private Spawner _spawner;
    public Vector3[] positions = new Vector3[5]
    {
        new Vector3(5, 5, 0),
        new Vector3(4, 4, 0),
        new Vector3(3, 3, 0),
        new Vector3(2, 2, 0),
        new Vector3(1, 1, 0)
    };
    public Vector3[] rotation = new Vector3[5]{
        new Vector3(1, 0, 0),
        new Vector3(0, 2, 0),
        new Vector3(3, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, 5)
    };

    private void Awake()
    {
        _avatar = GetComponentInParent<Alteruna.Avatar>();
        _spawner = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Spawner>();
    }

    public void SpawnMoney()
    {
        if (!hasSpawned)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 currentPosition = positions[i];
                Vector3 currentRotation = rotation[i];
                _spawner.Spawn(0, currentPosition, currentRotation, new Vector3(20, 10, 0.5f));
                Debug.Log(i);
                if (i == 4) hasSpawned = true;
            }
        }
    }

    [SynchronizableMethod]
    void DespawnMoney(GameObject money)
    {
        _spawner.Despawn(money);
    }
}
