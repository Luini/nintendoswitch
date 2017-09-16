using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerObject : Photon.MonoBehaviour
{

    public bool isParent = false;
    public string targetObject = "";

    public float clearTime = 0;

	// Use this for initialization
	void Start () {
        if (!isParent) ChangeColor();
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        LazerObject lazer = GetComponent<LazerObject>();
        if (gameController.myLazer != lazer) gameController.oppLazer = lazer;
    }

    void ChangeColor () {
        LineRenderer line = GetComponent<LineRenderer>();
        line.startColor = Color.blue;
        line.endColor = Color.blue;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(isParent);
            stream.SendNext(targetObject);
            stream.SendNext(clearTime);
        }
        else
        {
            isParent = (bool)stream.ReceiveNext();
            targetObject = (string)stream.ReceiveNext();
            clearTime = (float)stream.ReceiveNext();
        }
    }
}
