using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
public class Setup : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomnameinput;
    public void SinglePlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void Multi()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("Connected");
    }
    public void JoinRoom(RoomInfo roominfo)
    {
        PhotonNetwork.JoinRoom(roominfo.Name); 
    }
    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(roomnameinput.text))
        {
            roomnameinput.text = Random.Range(1, 1000).ToString();
        }
        PhotonNetwork.CreateRoom(roomnameinput.text);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(2);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to Join Room");
    }

}
