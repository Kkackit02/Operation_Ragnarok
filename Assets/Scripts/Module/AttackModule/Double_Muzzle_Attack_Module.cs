using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Muzzle_Attack_Module : Attack_Module
{
 
    protected override void Attack_Func()
    {
        if (isAttack == true)
        {
            Debug.Log("D1_Shoot");
            var Bullet1 = Instantiate(Bullet_Object, Muzzle_Part[0].transform);
            var Bullet2 = Instantiate(Bullet_Object, Muzzle_Part[1].transform);
            myAudio.PlayOneShot(SoundManager.Instance.DoubleAttackFire);
            Bullet1.transform.parent = null;
            Bullet2.transform.parent = null;
        }
    }

}

