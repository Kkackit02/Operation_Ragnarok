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

    public int floor = 0;

    private void Start()
    {
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
        ON_Joint();
        
    }

    public virtual void OnMouseExit()
    {
        OFF_Joint();
    }


    public void Sort_Floor()
    {
        if(Contact_Joint.GetComponent<Module>().floor < floor)
        {
            gameObject.transform.parent = Contact_Joint.transform.parent;
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
            Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
            
        if (Back_Joint_Part != null)
        {
            Back_Joint_Part.gameObject.tag = "Joint";
            Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
            
        if (Left_Joint_Part != null)
        {
            Left_Joint_Part.gameObject.tag = "Joint";
            Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
            
        if (Right_Joint_Part != null)
        {
            Right_Joint_Part.gameObject.tag = "Joint";
            Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
            
    }
    public virtual void Change_Tag_To_Jointed(GameObject Joint)
    {
        if(Joint.transform.name == "Forward")
        {
            Back_Joint_Part.gameObject.tag = "Jointed";
            Back_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        }
        else if(Joint.transform.name == "Back")
        {
            Forward_Joint_Part.gameObject.tag = "Jointed";
            Forward_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        }
        else if (Joint.transform.name == "Right")
        {
            Left_Joint_Part.gameObject.tag = "Jointed";
            Left_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        }
        else if (Joint.transform.name == "Left")
        {
            Right_Joint_Part.gameObject.tag = "Jointed";
            Right_Joint_Part.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
        }
    }




    public override void OnMouseUpAsButton()
    {
        isDraging = false;
        if (isContact && isConnect == false) // 부착 전에 접합부에 닿았을 때
        {
            Change_Tag_To_Joint();
            if (Contact_Joint != null)
            {
                transform.position = Contact_Joint.transform.position;
                Parent = Contact_Joint.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                this.gameObject.transform.parent = Parent.transform;
                
                Contact_Joint.gameObject.tag = "Jointed";
                Change_Tag_To_Jointed(Contact_Joint);
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            } 
            isConnect = true;
            
            
            GameManager.Instance.Joint_Part.Add(gameObject);
            GameManager.Instance.connected_Moudule_Count++;
        }
        if (isContact && isConnect) // 부착 후 떼어냈다가 접합부에 닿았을 때
        {
            Change_Tag_To_Joint();
            if (Contact_Joint != null)
            {
                transform.position = Contact_Joint.transform.position;
                Parent = Contact_Joint.gameObject.transform.parent.gameObject.transform.parent.gameObject;
                this.gameObject.transform.parent = Parent.transform;

                Contact_Joint.gameObject.tag = "Jointed";
                Change_Tag_To_Jointed(Contact_Joint);
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 0.01f);
            }
            isConnect = true;
            
            
        }
        else if (!isContact && isConnect)  // 부착 후 떼어냈을때(접합부에서 떨어졌을때)
        {
            if(Contact_Joint != null)
            {
                Contact_Joint.gameObject.tag = "Joint";
                Contact_Joint.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
                Contact_Joint = null;
                
            }
            
            this.gameObject.transform.parent = null;
            Parent = null;
            isConnect = false;
            
            Blind_Joint();
            Change_Tag_To_Joint();
            GameManager.Instance.Joint_Part.Remove(gameObject);
            GameManager.Instance.connected_Moudule_Count--;
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

        if(isConnect == false && isDraging == true)
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
            //collision.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);

        }
        if(collision.CompareTag("Joint"))
        {
            if(isConnect == false)
            {
                isContact = false;
            }
        }
    }
}
