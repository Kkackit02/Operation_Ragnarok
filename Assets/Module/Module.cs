using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : Drag
{
    public GameObject Forward_Joint_Part;
    public GameObject Back_Joint_Part;
    public GameObject Left_Joint_Part;
    public GameObject Right_Joint_Part;

    public GameObject Parent;
    public GameObject Contact_Joint;

    public bool isConnect = false;
    public bool isContact = false;
    public bool isActive = false;

    private float Module_Mass = 0.5f;
    public int DirCode; //0 = null, 1 = forward, 2 = back, 3 = left, 4 = right

    public int floor = 0;

    private void Start()
    {
        
        

        /*
         * ��ǰ���� �ٸ��� ���ּ���.

        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        */
    }



    public virtual void OnMouseOver()
    {
        ON_Joint();
        
    }

    public virtual void OnMouseExit()
    {
        OFF_Joint();
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
            
            Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Back_Joint_Part != null)
        {
            Back_Joint_Part.gameObject.tag = "Joint";
            Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Left_Joint_Part != null)
        {
            Left_Joint_Part.gameObject.tag = "Joint";
            Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
        if (Right_Joint_Part != null)
        {
            Right_Joint_Part.gameObject.tag = "Joint";
            Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.0f, 1.0f);
        }
            
    }
    public virtual void Change_Tag_To_Jointed(GameObject Joint)
    {
        if(Joint.transform.name == "Forward")
        {
            if (Back_Joint_Part != null)
            {
                Back_Joint_Part.gameObject.tag = "Jointed";
                Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
                
        }
        else if(Joint.transform.name == "Back")
        {
            if(Forward_Joint_Part != null)
            {
                Forward_Joint_Part.gameObject.tag = "Jointed";
                Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            
        }
        else if (Joint.transform.name == "Right")
        {
            if (Left_Joint_Part != null)
            {
                Left_Joint_Part.gameObject.tag = "Jointed";
                Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            
        }
        else if (Joint.transform.name == "Left")
        {
            if (Right_Joint_Part != null)
            {
                Right_Joint_Part.gameObject.tag = "Jointed";
                Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
        }
    }

    public virtual void Change_Dir(GameObject Joint)
    {
        if (Joint.transform.name == "Forward")
        {
            DirCode = 1;

        }
        else if (Joint.transform.name == "Back")
        {
            DirCode = 2;

        }
        else if (Joint.transform.name == "Left")
        {
            DirCode = 3;

        }
        else if (Joint.transform.name == "Right")
        {
            DirCode = 4;
        }
    }
    public virtual void Reset_Dir()
    {
        DirCode = 0;
    }
    
    public virtual void Destroy_Module()
    {

    }


    public override void OnMouseUpAsButton()
    {
        isDraging = false;
        if (isContact && isConnect == false) // ���� ���� ���պο� ����� ��
        {
            Change_Tag_To_Joint();
            if (Contact_Joint != null)
            {
                transform.position = Contact_Joint.transform.position;
                //GetComponent<FixedJoint2D>().connectedBody = Contact_Joint.gameObject.GetComponent<Rigidbody2D>();
                Parent = Contact_Joint.gameObject;
                this.gameObject.transform.parent = Parent.transform;
                gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                GetComponent<Rigidbody2D>().isKinematic = true;

                Contact_Joint.gameObject.tag = "Jointed";
                ON_Joint();
                Change_Tag_To_Jointed(Contact_Joint);
                Change_Dir(Contact_Joint);
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            } 
            isConnect = true;
            
            
            GameManager.Instance.Joint_Part.Add(gameObject);
            GameManager.Instance.connected_Moudule_Count++;
            GameManager.Instance.MainShip_Module_Script.AddMass(Module_Mass);
        }
        if (isContact && isConnect) // ���� �� ����´ٰ� ���պο� ����� ��
        {
            Change_Tag_To_Joint();
            if (Contact_Joint != null)
            {
                transform.position = Contact_Joint.transform.position;
                //GetComponent<FixedJoint2D>().connectedBody = Contact_Joint.gameObject.GetComponent<Rigidbody2D>();
                Parent = Contact_Joint.gameObject;
                this.gameObject.transform.parent = Parent.transform;
                GetComponent<Rigidbody2D>().isKinematic = true;
                gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Contact_Joint.gameObject.tag = "Jointed";
                ON_Joint();
                Change_Tag_To_Jointed(Contact_Joint);
                Change_Dir(Contact_Joint);
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            isConnect = true;
        }
        else if (!isContact && isConnect)  // ���� �� ���������(���պο��� ����������)
        {
            if(Contact_Joint != null)
            {
                Contact_Joint.gameObject.tag = "Joint";
                //GetComponent<FixedJoint2D>().connectedBody = null;
                GetComponent<Rigidbody2D>().isKinematic = false;
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
                Contact_Joint = null;
                OFF_Joint();
            }
            
            this.gameObject.transform.parent = null;
            Parent = null;
            isConnect = false;
            
            Blind_Joint();
            Change_Tag_To_Joint();
            Reset_Dir();
            GameManager.Instance.Joint_Part.Remove(gameObject);
            GameManager.Instance.connected_Moudule_Count--;
            GameManager.Instance.MainShip_Module_Script.AddMass(-Module_Mass);
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
