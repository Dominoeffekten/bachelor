using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void ConnectToServer()
    {
        //Connect to server
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to Server...");

    }

    //When connected to server this is run OnConnectedToMaster()
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server.");
        base.OnConnectedToMaster();
        //laver options for rummet
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        //Alle spillere kan se rummet
        roomOptions.IsVisible = true;
        //IsOpen er sat til true så vi kan joine rummet
        roomOptions.IsOpen = true;
        //Forbinder til et rum, roomOptions er den anden variable
        PhotonNetwork.JoinOrCreateRoom("Room 1", roomOptions, TypedLobby.Default);
    }

    //bruges til at override nogen funktioner hvis rummet er joinet
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room.");
        base.OnJoinedRoom();
    }

    //newPlayer er en variable der giver data om spilleren, her bruger
    //vi det til at se om der er en der har joinet rummet
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
