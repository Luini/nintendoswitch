using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.SceneManagement;

public class MatchingManager : Photon.PunBehaviour {

    public GameObject testUI;
    public GameObject makeOrSearch;
    public GameObject roomList;
    public GameObject roomListButtonPrefab;

    private const string SCENE_NAME = "InGame";

    private bool isParent = false;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
        PhotonNetwork.logLevel = PhotonLogLevel.Full; // 詳細ログ
        PhotonNetwork.ConnectUsingSettings("0.1"); // 初期設定

        SceneManager.sceneLoaded += OnLoadedScene; // シーンロードのコールバッグを追加
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
        if(!isParent) SceneManager.LoadScene("InGameB");
    }

    // 誰かがルームに入った
    void OnPhotonPlayerConnected()
    {
        if(isParent) SceneManager.LoadScene("InGameA");
    }

    private void OnLoadedScene(Scene i_scene, LoadSceneMode i_mode)
    {
        // シーンの遷移が完了したら自分用のオブジェクトを生成.
        string sceneName = SCENE_NAME;
        sceneName += isParent ? "A" : "B";
        if (i_scene.name == sceneName)
        {
            MakePhotonObject();
        }
    }

    // 共有オブジェクトの生成
    void MakePhotonObject()
    {
        //キャラクター作成
        GameObject obj = PhotonNetwork.Instantiate("Prefabs/LazerObject", Vector3.zero, Quaternion.identity, 0);
        obj.transform.SetParent(Camera.main.transform, false);
        LazerObject lazer = obj.GetComponent<LazerObject>();
        lazer.isParent = isParent;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().myLazer = lazer;
    }

    //******************************//
    // Roomjoin系
    public void MakeRoom()
    {
        makeOrSearch.SetActive(false);
        //部屋を自分で作って入る
        PhotonNetwork.CreateRoom(null);
        isParent = true;
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
    //******************************//
}
