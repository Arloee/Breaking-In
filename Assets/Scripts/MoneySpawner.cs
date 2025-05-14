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
        for (int i = 0; i < 5; i++)
        {
            Vector3 currentPosition = positions[i];
            Vector3 currentRotation = rotation[i];
            _spawner.Spawn(0, currentPosition, currentRotation, new Vector3(20, 10, 0.5f));
            Debug.Log(i);
        }
    }

    public void GetRoom(Multiplayer multiplayer, Room room, User user)
    {
        bool noMatches = true;

        foreach (string server in servers)
        {
            if (room.Name == server)
            {
                noMatches = false;
                break;
            }
        }

        if (noMatches)
        {
            servers.Add(room.Name);
            SpawnMoney();
        }
    }

    [SynchronizableMethod]
    void DespawnMoney(RaycastHit money)
    {
        _spawner.Despawn(money.transform.gameObject);
    }
}
