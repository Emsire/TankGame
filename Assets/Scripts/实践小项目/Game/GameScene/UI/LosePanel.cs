using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : BasePanel<LosePanel>
{
    public CustomGUIButton btnBack;
    public CustomGUIButton btnGoOn;

    private void Start()
    {
        btnBack.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnGoOn.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };

        HideMe();
    }
}
