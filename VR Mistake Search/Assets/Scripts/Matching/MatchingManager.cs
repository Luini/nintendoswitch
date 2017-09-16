using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class MatchingManager : Photon.PunBehaviour {

    public GameObject testUI;
    public GameObject makeOrSearch;
    public GameObject roomList;
    public GameObject roomListButtonPrefab;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.logLevel = PhotonLogLevel.Full; // 詳細ログ
        PhotonNetwork.ConnectUsingSettings("0.1"); // 初期設定
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    // ロビー入った際のコールバッグ
    void OnJoinedLobby()
    {
        testUI.SetActive(true);
    }

    //ルームに入室成功
    void OnJoinedRoom()
    {
        //キャラクター作成
        GameObject obj = PhotonNetwork.Instantiate("Prefabs/PhotonObject", Vector3.zero, Quaternion.identity, 0);
        obj.transform.SetParent(transform, false);
        DontDestroyOnLoad(obj);
    }

    public void MakeRoom()
    {
        makeOrSearch.SetActive(false);
        //部屋を自分で作って入る
        PhotonNetwork.CreateRoom(null);
    }

    public void SearchRoom()
    {
        makeOrSearch.SetActive(false);
        RoomInfo[] roomInfos = PhotonNetwork.GetRoomList();
        for (int i = 0; i < roomInfos.Length; i++)
        {
            GameObject button = Instantiate<GameObject>(roomListButtonPrefab);
            button.transform.position = new Vector3(0, i * -50, 0);
            button.transform.SetParent(roomList.transform, false);
            button.SendMessage("SetRoomName", roomInfos[i].Name);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
