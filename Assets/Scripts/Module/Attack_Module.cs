using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : Module
{
    
    
    public List<GameObject> Muzzle_Part;
    public bool isAttack;
    public GameObject Bullet_Object;

    private float module_Damage = 10f;
    private float module_Dalay = 0.3f;
    public enum Attack_State // °¢µµ
    {
        Stop,
        Attack
    }

    public Attack_State attack_State = Attack_State.Stop;
    void Start()
    {
        StartCoroutine(Attack());
        //Back_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Blind_Joint();
        OFF_Joint();

        module_Damage = module_Data.ModuleDamage;
        module_Dalay = module_Data.AttackDalay;
    }


    private IEnumerator Attack()
    {
        while(true)
        {
            if(isAttack == true)
            {
                var Bullet = Instantiate(Bullet_Object, Muzzle_Part[0].transform);
                Bullet.transform.parent = null;
            }
            
            yield return new WaitForSeconds(0.3f);
        }
    }
    void Update()
    {
        if (isConnect == true && attack_State == Attack_State.Stop)
        {
            isAttack = false;
        }
        else if (isConnect == true && attack_State == Attack_State.Attack)
        {
            isAttack = true;
        }

        if (isConnect == true && isPlayer)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }
        }
        
        
        
    }

    public override void OnMouseOver()
    {
        if(isPlayer)
        GameManager.Instance.Display_Ship_Joint();
        //OFF_Joint();
    }

    public override void OnMouseExit()
    {
        if(isPlayer)
        GameManager.Instance.Blind_Ship_Joint();
        //ON_Joint();
    }


}
