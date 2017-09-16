using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSelectedScript : MonoBehaviour, SelectedUI
{
    public void Selected()
    {
        SceneManager.LoadScene("");
    }
}
