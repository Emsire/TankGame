using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;

    public Transform weaponPos;
    void Update()
    {
        this.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime);
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) 
            Fire();
    }

    public override void Fire()
    {
        if (nowWeapon != null)
            nowWeapon.Fire();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        GamePanel.Instance.UpdateHP(this.maxHp, this.hp);
    }

    public override void Dead()
    {
        //base.Dead();
        Time.timeScale = 0;
        LosePanel.Instance.ShowMe();
    }

    public void ChangeWeapon(GameObject weapon)
    {
        if(nowWeapon!=null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        nowWeapon.SetFather(this);
    }
}
