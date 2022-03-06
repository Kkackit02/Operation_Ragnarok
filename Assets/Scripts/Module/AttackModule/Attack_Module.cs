using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : Module
{
    
    
    public List<GameObject> Muzzle_Part;
    public bool isAttack;
    public GameObject Bullet_Object;
    private AudioClip Shot_Sound;
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
        Shot_Sound = SoundManager.Instance.AttackFire;
        Decomposite_Sound = SoundManager.Instance.Decomposite;
        Composite_Sound = SoundManager.Instance.Composite;
        BulletHit_Sound = SoundManager.Instance.BulletHit;
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = 0.6f;
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
            myAudio.PlayOneShot(Shot_Sound);
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

    public override void Decompose_Module(bool hasConnect)
    {
        if (Contact_Joint != null)
        {
            Contact_Joint.gameObject.tag = "Joint";
            //GetComponent<FixedJoint2D>().connectedBody = null;
            GetComponent<Rigidbody2D>().isKinematic = false;
            Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
            Contact_Joint = null;
            OFF_Joint();
        }
        Reset_Flag();
        this.gameObject.transform.parent = null;
        Parent = null;
        isConnect = false;

        Blind_Joint();
        Change_Tag_To_Joint();
        Reset_Dir();

        GetComponent<Rigidbody2D>().AddForce
            (new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)), ForceMode2D.Impulse);
        myAudio.PlayOneShot(Decomposite_Sound);

        if (hasConnect == true && canAccess == true && isPlayer)
        {
            GameManager.Instance.Joint_Part.Remove(gameObject);
            GameManager.Instance.connected_Moudule_Count--;
            GameManager.Instance.MainShip_Module_Script.AddMass(-Module_Mass);
            isPlayer = false;

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
