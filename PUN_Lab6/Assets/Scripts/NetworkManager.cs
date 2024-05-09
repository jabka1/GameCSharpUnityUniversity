using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room.");
        if (playerPrefab != null)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player prefab is not assigned in the inspector!");
        }
    }
}
