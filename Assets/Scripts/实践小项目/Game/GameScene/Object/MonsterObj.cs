using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //让坦克在随机点之间来回移动
    private Transform targetPos; 
    public Transform[] randomPos;

    //坦克始终面朝向玩家
    public Transform lookAtTarget;

    //坦克和玩家距离过近就会开火
    public float fireDis = 10;
    public float fireOffSetTime = 1;
    private float nowTime = 0;

    public GameObject bulletObj;
    public Transform[] shootPos;


    //血条相关
    public Texture maxHpBK;
    public Texture hpBK;

    private Rect maxHpRect;
    private Rect hpRect;

    private float showTime = 0;

    private void Start()
    {
        RandomPos();
    }

    private void Update()
    {
        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if(Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }


        if(lookAtTarget != null)
        {
            tankHead.LookAt(lookAtTarget);
            if(Vector3.Distance(this.transform.position, lookAtTarget.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime >= fireOffSetTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0) return;

        targetPos = randomPos[Random.Range(0, randomPos.Length)];
    }
    public override void Fire()
    {
        for(int i=0;i<shootPos.Length;i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);
        }
    }

    private void OnGUI()
    {
        if(showTime > 0)
        {
            showTime -= Time.deltaTime;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;

            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 150 * (40f - screenPos.z) / 30;
            maxHpRect.height = 20 * (40f - screenPos.z) / 30;
            GUI.DrawTexture(maxHpRect, maxHpBK);

            hpRect.x = screenPos.x - 50; 
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHp * 150f * (40f - screenPos.z) / 30;
            hpRect.height = 20 * (40f - screenPos.z) / 30;
            GUI.DrawTexture(hpRect, hpBK);
        }
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3;
    }
}
