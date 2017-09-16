using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerObject : Photon.MonoBehaviour
{

    public bool isParent = false;
    public string targetObject;

	// Use this for initialization
	void Start () {
        if (!isParent) ChangeColor();

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
        }
        else
        {
            isParent = (bool)stream.ReceiveNext();
            targetObject = (string)stream.ReceiveNext();
        }
    }
}
