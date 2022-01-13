using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelDie : MonoBehaviour
{
    private void Start()
    {
        GameInfo.init.CheckPlayer.DieAction += Show;
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        GameInfo.init.CheckPlayer.DieAction -= Show;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
