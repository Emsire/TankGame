using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;
    public GameObject effObj;

    public TankBaseObj fatherObj;
    
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube") || 
            other.CompareTag("Player") && fatherObj.CompareTag("Monster") ||
            other.CompareTag("Monster") && fatherObj.CompareTag("Player"))
        {
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
                obj.Wound(fatherObj);

            if(effObj != null)
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                AudioSource audioS = eff.GetComponent<AudioSource>();
                audioS.volume = GameDataMgr.Instance.musicData.soundValue;
                audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            Destroy(this.gameObject);
        }
    }

    public void SetFather(TankBaseObj obj)
    {
        fatherObj = obj;
    }
}
