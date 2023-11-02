using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boxBlue;
    [SerializeField] private GameObject boxRed;
    [SerializeField] private Transform spawnPoint;
    public void SpawnBox(ulong clientID)
    {
        var position = spawnPoint.transform.position;
        var spawnPosition = new Vector3(Random.Range(-4.0f,4.0f),position.y,position.z);

        switch (clientID)
        {
            case 1:
            {
                var spawnedBox = Instantiate(boxBlue, spawnPosition, Quaternion.identity);
                spawnedBox.GetComponent<NetworkObject>().Spawn(true);
                break;
            }
            case 2:
            {
                var spawnedBox = Instantiate(boxRed, spawnPosition, Quaternion.identity);
                spawnedBox.GetComponent<NetworkObject>().Spawn(true);
                break;
            }
        }
    }
}
