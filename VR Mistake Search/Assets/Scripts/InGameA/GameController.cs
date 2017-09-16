using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    int mistakeCount = 0;

    public LazerObject myLazer;
    public LazerObject oppLazer;

    bool answer1Flag = false;
    bool answer2Flag = false;

    bool isParet = false;
    float time = 0;

    public GameObject clearPanel;

    bool finishFlag = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!finishFlag)
        {
            if (isParet)
            {
                time += Time.deltaTime;

                if (myLazer.targetObject == oppLazer.targetObject)
                {
                    Debug.Log("sdffdsafsda: " + myLazer.targetObject);
                    if (myLazer.targetObject == "Answer1") answer1Flag = true;
                    if (myLazer.targetObject == "Answer2") answer2Flag = true;
                }
                if (answer1Flag && answer2Flag)
                {
                    myLazer.clearTime = time;
                }
            }

            Debug.Log(answer1Flag + " " + answer2Flag);

            // クリア判定
            if ((isParet && myLazer.clearTime != 0) || (!isParet && oppLazer.clearTime != 0))
            {
                finishFlag = true;
                clearPanel.SetActive(true);
                clearPanel.GetComponentInChildren<Text>().text = "Clear Time : " + myLazer.clearTime + " s";
            }
        }
    }

    public void SetTargetObject(string objName)
    {
        myLazer.targetObject = objName;
    }
}
