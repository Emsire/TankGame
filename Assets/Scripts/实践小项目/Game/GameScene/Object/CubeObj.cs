using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjects;

    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        BulletObj obj = other.GetComponent<BulletObj>();
        if(obj!=null && obj.fatherObj.CompareTag("Player"))
        {
            int rangeInt = Random.Range(0, 100);
            if (rangeInt < 50)
            {
                rangeInt = Random.Range(0, rewardObjects.Length);
                Instantiate(rewardObjects[rangeInt], this.transform.position, this.transform.rotation);
            }

            GameObject effObj = Instantiate(deadEff, this.transform.position, this.transform.rotation);
            AudioSource audioS = effObj.GetComponent<AudioSource>();
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            Destroy(this.gameObject);
        }
    }
}
