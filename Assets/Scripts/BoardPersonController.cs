using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Random = UnityEngine.Random;

public class BoardPersonController : NetworkBehaviour
{
    [SerializeField] private Button drawButton;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private AudioListener playerAudioListener;
    [SerializeField] private GameObject rotatorArm;
    
    [SerializeField] private Deck playerDeck;
    [SerializeField] private GameObject cardInstance;
    [SerializeField] private GameObject playerHandCanvas;
    
    private GameObject[] _redGridObjects;
    private GameObject[] _blueGridObjects;

    private GameObject _boxSpawnerObject;

    private int _numberOfCards;
    private List<Card> _shuffledDeck;
    
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
        _redGridObjects = GameObject.FindGameObjectsWithTag("Red");
        _blueGridObjects = GameObject.FindGameObjectsWithTag("Blue");
        
        // _shuffledDeck = new List<Card>();
        // _shuffledDeck = playerDeck.Decklist.OrderBy(_ => Guid.NewGuid()).ToList();
        // _numberOfCards = _shuffledDeck.Count;
    }

    private void Awake()
    {
        _boxSpawnerObject = GameObject.Find("GameManager");
        drawButton.onClick.AddListener(AddCard);
        // drawButton.onClick.AddListener(BoxSpawnServerRpc);
        // drawButton.onClick.AddListener(GridChangeServerRpc);
    }

    // [ServerRpc]
    // private void BoxSpawnServerRpc()
    // {
    //     if (_boxSpawnerObject == null) return;
    //     var boxSpawner = _boxSpawnerObject.GetComponent<BoxSpawner>();
    //
    //     if (boxSpawner == null) return;
    //     boxSpawner.SpawnBox(OwnerClientId);
    //     Debug.Log(OwnerClientId);
    // }
    //
    // [ServerRpc]
    // private void GridChangeServerRpc()
    // {
    //
    // }

    private void AddCard()
    {
        // cardInstance.GetComponent<DisplayCard>().ChangeCard(playerDeck.Decklist[_numberOfCards]);
        Instantiate(cardInstance, playerHandCanvas.transform);
        _numberOfCards--;
    }
}