using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;

    public CustomGUIToggle togMuisic;
    public CustomGUIToggle togSound;

    public CustomGUIButton btnClose;

    private GameObject player;
    void Start()
    {
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBKValue(value);

        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSound(value);

        togMuisic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBKMusic(value);

        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);

        btnClose.clickEvent += () =>
        {
            HideMe();
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowMe();
            }
        };

        HideMe();
    }

    public void UpdatePanelInfo()
    {
        MusicData data = GameDataMgr.Instance.musicData;

        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMuisic.isSel = data.isOpenMusic;
        togSound.isSel = data.isOpenSound;
    }

    public override void ShowMe()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (player != null)
                player.GetComponent<PlayerObj>().enabled = false;
        }
        base.ShowMe();
        UpdatePanelInfo();
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
