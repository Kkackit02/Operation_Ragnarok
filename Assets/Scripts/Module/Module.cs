using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Drag
{
    public bool canAccess = false;

    public GameObject DestroyEffect;

    public GameObject Forward_Joint_Part;
    public GameObject Back_Joint_Part;
    public GameObject Left_Joint_Part;
    public GameObject Right_Joint_Part;

    public GameObject Parent;
    public GameObject Contact_Joint;
    public ModuleData module_Data;

    public bool isConnect = false;
    public bool isContact = false;
    public bool isActive = false;
    public bool isDestroy = false;
    protected float Module_Mass = 0.5f;
    public int DirCode; //0 = null, 1 = forward, 2 = back, 3 = left, 4 = right

    protected float Module_Hp = 100f;

    protected AudioClip Composite_Sound;
    protected AudioClip Decomposite_Sound;
    protected AudioClip BulletHit_Sound;

    protected AudioSource myAudio;

    public int floor = 0;
    public bool isPlayer = false;
    private void Start()
    {
        Composite_Sound = SoundManager.Instance.Composite;
        Decomposite_Sound = SoundManager.Instance.Decomposite;
        BulletHit_Sound = SoundManager.Instance.BulletHit;
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = 0.6f;
        Module_Hp = module_Data.ModuleHp;
        Module_Mass = module_Data.ModuleMass;

        /*
         * 부품별로 다르게 해주세요.

        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        */
    }



    public virtual void OnMouseOver()
    {
        if(canAccess == true)
        {
            ON_Joint();
            Display_Joint();
        }
        
    }

    public virtual void OnMouseExit()
    {
        if(canAccess == true)
        {
            OFF_Joint();
            Blind_Joint();
        }
    }




    public virtual void Display_Joint()
    {
        if(Forward_Joint_Part != null)
            Forward_Joint_Part.GetComponent<SpriteRenderer>().enabled = true;
        if (Back_Joint_Part != null)
            Back_Joint_Part.GetComponent<SpriteRenderer>().enabled = true;
        if (Left_Joint_Part != null)
            Left_Joint_Part.GetComponent<SpriteRenderer>().enabled = true;
        if (Right_Joint_Part != null)
            Right_Joint_Part.GetComponent<SpriteRenderer>().enabled = true;
    }

    public virtual void Blind_Joint()
    {
        if (Forward_Joint_Part != null)
            Forward_Joint_Part.GetComponent<SpriteRenderer>().enabled = false;
        if (Back_Joint_Part != null)
            Back_Joint_Part.GetComponent<SpriteRenderer>().enabled = false;
        if (Left_Joint_Part != null)
            Left_Joint_Part.GetComponent<SpriteRenderer>().enabled = false;
        if (Right_Joint_Part != null)
            Right_Joint_Part.GetComponent<SpriteRenderer>().enabled = false;
    }

    public virtual void OFF_Joint()
    {
        if (Forward_Joint_Part != null)
            Forward_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
        if (Back_Joint_Part != null)
            Back_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
        if (Left_Joint_Part != null)
            Left_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
        if (Right_Joint_Part != null)
            Right_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
    }

    public virtual void ON_Joint()
    {
        if (Forward_Joint_Part != null)
            Forward_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
        if (Back_Joint_Part != null)
            Back_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
        if (Left_Joint_Part != null)
            Left_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
        if (Right_Joint_Part != null)
            Right_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
    }

    public virtual void Change_Tag_To_Joint()
    {
        if (Forward_Joint_Part != null)
        {
            Forward_Joint_Part.gameObject.tag = "Joint";
            Forward_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
            //Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Back_Joint_Part != null)
        {
            Back_Joint_Part.gameObject.tag = "Joint";
            Back_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
            //Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Left_Joint_Part != null)
        {
            Left_Joint_Part.gameObject.tag = "Joint";
            Left_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
            //Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Right_Joint_Part != null)
        {
            Right_Joint_Part.gameObject.tag = "Joint";
            Right_Joint_Part.GetComponent<BoxCollider2D>().enabled = true;
            //Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
    }
    public virtual void Change_Tag_To_Jointed(GameObject Joint)
    {
        if(Joint.transform.name == "Forward")
        {
            if (Back_Joint_Part != null)
            {
                Back_Joint_Part.gameObject.tag = "Jointed";
                Back_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
                //Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
                
        }
        else if(Joint.transform.name == "Back")
        {
            if(Forward_Joint_Part != null)
            {
                Forward_Joint_Part.gameObject.tag = "Jointed";
                Forward_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
                //Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            
        }
        else if (Joint.transform.name == "Right")
        {
            if (Left_Joint_Part != null)
            {
                Left_Joint_Part.gameObject.tag = "Jointed";
                Left_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
                //Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            
        }
        else if (Joint.transform.name == "Left")
        {
            if (Right_Joint_Part != null)
            {
                Right_Joint_Part.gameObject.tag = "Jointed";
                Right_Joint_Part.GetComponent<BoxCollider2D>().enabled = false;
                //Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
        }
    }

    public virtual void Change_Dir(GameObject Joint)
    {
        if (Joint.transform.name == "Forward")
        {
            DirCode = 1;
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }
        else if (Joint.transform.name == "Back")
        {
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
            DirCode = 2;

        }
        else if (Joint.transform.name == "Left")
        {
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            DirCode = 3;

        }
        else if (Joint.transform.name == "Right")
        {
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 270));
            DirCode = 4;
        }
    }
    public virtual void Reset_Dir()
    {
        DirCode = 0;
    }
    
    public virtual void Destroy_Module()
    {
        if(isDestroy == false)
        {
            Decompose_Module(true);
            GameObject A = Instantiate(DestroyEffect, this.gameObject.transform);
            myAudio.PlayOneShot(SoundManager.Instance.DestroyModule);
            Destroy(this.gameObject, 1.5f);
            isDestroy = true;
        }
        
    }

    
    public virtual void Update_Module_HP(float value)
    {
        Module_Hp -= value;
        myAudio.PlayOneShot(BulletHit_Sound);
        
        if (Module_Hp <= 0)
        {
            
            Destroy_Module();
        }

    }


    public virtual void Compose_Module()
    {
        Change_Tag_To_Joint();
        isConnect = true;
        isContact = true;
        if (Contact_Joint != null)
        {
            isPlayer = true;
            transform.position = Contact_Joint.transform.position;
            //GetComponent<FixedJoint2D>().connectedBody = Contact_Joint.gameObject.GetComponent<Rigidbody2D>();
            Parent = Contact_Joint.gameObject;
            this.gameObject.transform.parent = Parent.transform;
            GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Contact_Joint.gameObject.tag = "Jointed";
            Reset_Flag();
            ON_Joint();
            Change_Tag_To_Jointed(Contact_Joint);
            Change_Dir(Contact_Joint);
            Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            Set_Rd();
        }
        isConnect = true;
        isContact = true;
        myAudio.PlayOneShot(Composite_Sound);
    }

    public virtual void Decompose_Module(bool hasConnect)
    {
        //연결된 부품들 분해
        if(Forward_Joint_Part != null)
        {
            if (Forward_Joint_Part.transform.childCount == 1)
            {
                Forward_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().canAccess = true;
                Forward_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().Decompose_Module(true);
            }
        }
        if(Back_Joint_Part != null)
        {
            if (Back_Joint_Part.transform.childCount == 1)
            {
                Back_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().canAccess = true;
                Back_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().Decompose_Module(true);
                
            }
        }
        if(Left_Joint_Part != null)
        {
            if (Left_Joint_Part.transform.childCount == 1)
            {
                Left_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().canAccess = true;
                Left_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().Decompose_Module(true);
                
            }
        }

        if(Right_Joint_Part != null)
        {
            if (Right_Joint_Part.transform.childCount == 1)
            {
                Right_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().canAccess = true;
                Right_Joint_Part.transform.GetChild(0).gameObject.GetComponent<Module>().Decompose_Module(true);
                
            }
        }

        if(Contact_Joint != null)
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

    protected virtual void Reset_Flag()
    {

    }

    protected virtual void Set_Rd()
    {

    }


    public override void OnMouseUpAsButton()
    {
        if(canAccess == true)
        {
            isDraging = false;
            if (isContact && !isConnect) // 부착 전에 접합부에 닿았을 때
            {
                Compose_Module();
                GameManager.Instance.Joint_Part.Add(gameObject);
                GameManager.Instance.connected_Moudule_Count++;
                GameManager.Instance.MainShip_Module_Script.AddMass(Module_Mass);
            }
            else if (isContact && isConnect) // 부착 후 떼어냈다가 접합부에 닿았을 때
            {
                Compose_Module();
            }
            else if (!isContact && isConnect)  // 부착 후 떼어냈을때(접합부에서 떨어졌을때)
            {
                Decompose_Module(isConnect);

            }
            else if (!isConnect && !isContact)
            {
                Decompose_Module(isConnect);
            }
        }
        
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jointed"))
        {
            collision.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        }
    }
    */


    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isConnect == false && isDraging == true)
        {
            if (collision.CompareTag("Joint"))
            {
                isContact = true;
                Contact_Joint = collision.gameObject;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jointed"))
        {
            isContact = false;
            //collision.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);

        }
        if (collision.CompareTag("Joint"))
        {
            if(isConnect == false)
            {
                isContact = false;
            }
        }
    }
}
