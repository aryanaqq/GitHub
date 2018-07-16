using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class AHitted : MonoBehaviour {

    public virtual AAttack Hitted<T>(GameObject attacker, T attackInfo) where T : AAttack {
        print("受到來自" + attacker.name + "使用" + attackInfo._weaponName + "造成的" + attackInfo._elementType + "傷害" + attackInfo._damage + "點");
        return attackInfo;
    }

    public virtual void GetParam(GameObject attacker, AAttack attackInfo) {
        Hitted(attacker, attackInfo);
    }
}

//Normal
public class Hitted1 : AHitted {
    public new void GetParam(GameObject attacker, AAttack attackInfo) {
    }
}
//Vunlerable
public class Hitted2 : AHitted {
    public override void GetParam(GameObject attacker, AAttack attackInfo) {
        attackInfo._damage *= 2f;
        GetParam(attacker, attackInfo);
    }
}


