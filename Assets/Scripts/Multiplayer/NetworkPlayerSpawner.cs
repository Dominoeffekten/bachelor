using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    //Denne funktion kører når vi joiner et rum
    public override void OnJoinedRoom()
    {
        //Spawn player
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    //Denne funktion kører når vi forlader et rum
    public override void OnLeftRoom()
    {
        //Disable player for alle andre spillere    
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
