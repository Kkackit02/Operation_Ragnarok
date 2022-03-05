using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : Module
{
    
    
    public List<GameObject> Muzzle_Part;
    public bool isAttack;
    public GameObject Bullet_Object;

    protected float module_Damage = 10f;
    protected float module_Dalay = 0.3f;
    public enum Attack_State // °¢µµ
    {
        Stop,
        Attack
    }

    public Attack_State attack_State = Attack_State.Stop;
    void Start()
    {

        myAudio = GetComponent<AudioSource>();
        myAudio.volume = 0.45f;
        StartCoroutine(Attack());
        //Back_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Blind_Joint();
        OFF_Joint();

        module_Damage = module_Data.ModuleDamage;
        module_Dalay = module_Data.AttackDalay;
    }


    protected virtual void Attack_Func()
    {
        if (isAttack == true)
        {
            myAudio.PlayOneShot(SoundManager.Instance.AttackFire);
            var Bullet = Instantiate(Bullet_Object, Muzzle_Part[0].transform);
            Bullet.transform.parent = null;
        }
    }

    private IEnumerator Attack()
    {
        while(true)
        {
            Attack_Func();
            
            yield return new WaitForSeconds(module_Dalay);
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
        else if(isConnect == false && attack_State == Attack_State.Stop)
        {
            isAttack = false;
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


    protected override void Reset_Flag()
    {
        attack_State = Attack_State.Stop;
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
