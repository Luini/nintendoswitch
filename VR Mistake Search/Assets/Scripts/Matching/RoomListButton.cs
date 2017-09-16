using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListButton : MonoBehaviour {

    MatchingManager matchingManager;

    public string roomName;

	// Use this for initialization
	void Awake () {
        matchingManager = GameObject.FindGameObjectWithTag("MatchingManager").GetComponent<MatchingManager>();
	}
	
    public void OnClick()
    {
        matchingManager.JoinRoom(roomName);
    }

    void SetRoomName(string roomName)
    {
        this.roomName = roomName;
        GetComponentInChildren<Text>().text = roomName;
    }
}
