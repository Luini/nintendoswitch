using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRSelectorScript : MonoBehaviour {

    /// <summary>
    /// 決定を促すためのセレクトUI
    /// </summary>
    public Image SelectedImage;

    /// <summary>
    /// 決定された時のUI
    /// </summary>
    public GameObject text;
    /// <summary>
    /// 念のため用意した選ばれているかのbool
    /// </summary>
    private bool isSelected = false;

    public bool IsSelected
    {
        get { return isSelected; }
        private set { isSelected = value; text.SetActive(value); }
    }

    /// <summary>
    /// 選択されるまでにかかる時間
    /// </summary>
    public float RangeTime;

    /// <summary>
    /// 今選ばれている時間
    /// </summary>
    [SerializeField]
    private float NowSelectedTime = 0;
	// Use this for initialization
	
    /// <summary>
    /// 時間を加算するメソッド
    /// ついでにUIの更新
    /// </summary>
    /// <param name="time">加算される時間</param>
    public void addTime(float time)
    {
        NowSelectedTime += time;
        SelectedImage.fillAmount = NowSelectedTime / RangeTime;
        if(SelectedImage.fillAmount >= 1)
        {
            IsSelected = true;
        }
    }

	// Update is called once per frame
    public void ResetTime()
    {
        NowSelectedTime = 0;
        SelectedImage.fillAmount = 0;
        IsSelected = false;
    }

}
