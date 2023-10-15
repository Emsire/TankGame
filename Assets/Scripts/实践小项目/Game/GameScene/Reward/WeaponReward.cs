using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //����Ԥ����
    public GameObject[] weaponObj;

    public GameObject getEff;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //�л�����
            int index = Random.Range(0, weaponObj.Length);
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            AudioSource audioS = eff.GetComponent<AudioSource>();
            audioS.volume = GameDataMgr.Instance.musicData.soundValue;
            audioS.mute = !GameDataMgr.Instance.musicData.isOpenSound;

            //����������������!
            Destroy(this.gameObject);
        }
    }
}
