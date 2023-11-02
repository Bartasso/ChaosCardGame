using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Random = UnityEngine.Random;

public class BoardPersonController : NetworkBehaviour
{
    [SerializeField] private Button shuffleButton;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private AudioListener playerAudioListener;
    [SerializeField] private GameObject rotatorArm;

    private GameObject _boxSpawnerObject;


    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            playerAudioListener.enabled = true;
            playerCamera.Priority = 1;
        }
        else
        {
            rotatorArm.SetActive(false);
            playerAudioListener.enabled = false;
            playerCamera.Priority = 0;
        }

        if (OwnerClientId != 1) return;
        var rot = rotatorArm.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);
        rotatorArm.transform.rotation = Quaternion.Euler(rot);
    }

    private void Awake()
    {
        _boxSpawnerObject = GameObject.Find("GameManager");
        shuffleButton.onClick.AddListener(BoxSpawnServerRpc);
    }

    [ServerRpc]
    private void BoxSpawnServerRpc()
    {
        if (_boxSpawnerObject == null) return;
        var boxSpawner = _boxSpawnerObject.GetComponent<BoxSpawner>();

        if (boxSpawner == null) return;
        boxSpawner.SpawnBox(OwnerClientId);
        Debug.Log(OwnerClientId);
    }
    
}