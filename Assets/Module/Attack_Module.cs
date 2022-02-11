using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : Module
{
    
    
    public List<GameObject> Muzzle_Part;
    public bool isAttack;
    public GameObject Bullet_Object;
    void Start()
    {
        StartCoroutine(Attack());
        Back_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Blind_Joint();
        OFF_Joint();
        
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
        if(Input.GetKey(KeyCode.Space))
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
    }

    public override void OnMouseOver()
    {
        GameManager.Instance.Display_Ship_Joint();
        //OFF_Joint();
    }

    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Ship_Joint();
        //ON_Joint();
    }


}
