using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AAttack:MonoBehaviour {
    public GameObject _theWeapon;
    public string _weaponName;
    public float _damage;
    public float _range;
    public string _elementType;
    public string _status;

    public virtual void Attack(GameObject theWeapon,string weaponName,float damage,float range = 1,string elementType = null,string status = null) {
        Vector3 OriginScale = theWeapon.transform.localScale;
        theWeapon.transform.localScale = new Vector3(OriginScale.x,OriginScale.y,range);
        WaitSeconds.Instance.Waits(0.5f,() => {
            theWeapon.transform.localScale = OriginScale;
            theWeapon.GetComponent<Collider>().enabled = false;
        });
        elementType = elementType ?? "一般";
        status = status ?? "普通傷害";
        //print("使用" + _weaponName + "攻擊造成" + elementType + "屬性傷害 " + damage + "點," + " 攻擊距離: " + range + ",造成" + status + "狀態");
        }

    public virtual void GetParam(GameObject theWeapon,string weaponName,float damage,float range = 1,string elementType = null,string status = null) {
        _theWeapon = theWeapon;
        _weaponName = weaponName;
        _damage = damage;
        _range = range;
        _elementType = elementType;
        _status = status;
        Attack(_theWeapon,_weaponName,_damage,_range,_elementType,_status);
        }
    }


public class Attack1:AAttack {
    public new void GetParam(GameObject theWeapon,string weaponName,float damage,float range,string elementType,string status) {
        }
    }

public class Attack2:AAttack {
    public override void GetParam(GameObject theWeapon,string weaponName,float damage,float range,string elementType,string status) {
        _theWeapon = theWeapon;
        _weaponName = weaponName;
        _damage = damage * 2;
        _range = range * 2;
        _elementType = elementType;
        _status = status;
        Attack(_theWeapon,_weaponName,_damage,_range,_elementType,_status);
        }
    }














