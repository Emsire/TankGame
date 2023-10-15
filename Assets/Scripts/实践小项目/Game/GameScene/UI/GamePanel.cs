using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;

    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;

    public CustomGUITexture texHP;

    [HideInInspector]
    public int nowScore = 0;

    [HideInInspector]
    public float nowTime = 0;
    private int time;

    //血条控件的宽
    public float hpw = 300;

    public GameObject player;

    private void Start()
    {
        SettingPanel.Instance.SetPlayer(player);
        QuitPanel.Instance.SetPlayer(player);
        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };

        btnQuit.clickEvent += () =>
        {
            QuitPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };

        //AddScore(100);
        //UpdateHP(100, 30);
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        time = (int)nowTime;
        labTime.content.text = "";
        if(time/3600 > 0)
        {
            labTime.content.text += time / 3600 + "时";
        }
        if(time%3600/60>0 || labTime.content.text!="")
        {
            labTime.content.text += time % 3600 / 60 + "分";
        }
        labTime.content.text += time % 60 + "秒";
    }

    public void AddScore(int score)
    {
        nowScore += score;
        labScore.content.text = nowScore.ToString();
    }

    public void UpdateHP(int maxHP, int HP)
    {
        texHP.guiPos.width = (float)HP / maxHP * hpw;
    }
}
