using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnGoOn;
    public CustomGUIButton btnClose;

    private GameObject player;
    private void Start()
    {
        btnQuit.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
        };

        btnGoOn.clickEvent += () =>
        {
            HideMe();
        };

        btnClose.clickEvent += () =>
        {
            HideMe();
        };

        HideMe();
    }

    public override void ShowMe()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (player != null)
                player.GetComponent<PlayerObj>().enabled = false;
        }
        base.ShowMe();
    }

    public override void HideMe()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (player != null)
                player.GetComponent<PlayerObj>().enabled = true;
        }
        base.HideMe();
        Time.timeScale = 1;
    }
    public void SetPlayer(GameObject obj)
    {
        player = obj;
    }
}
