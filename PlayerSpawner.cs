using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    
    private void Start()
    {
        

        int randomNumber = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomNumber];
        GameObject playerToSpawn;
        if (PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"] == null)
        {
            playerToSpawn = playerPrefabs[0];
            Debug.Log("Hello");
        }
        else
        {
            playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            Debug.Log("Não é Null");
        }
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);


    }
}
