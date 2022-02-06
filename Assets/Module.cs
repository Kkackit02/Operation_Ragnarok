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
    public GameObject Connected_Joint;
    public bool isConnect = false;

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

    void Update()
    {
        
    }

    public virtual void OnMouseOver()
    {
        /*
         * 부품별로 다르게 해주세요.
        Forward_Joint_Part.gameObject.SetActive(true);
        Back_Joint_Part.gameObject.SetActive(true);
        Left_Joint_Part.gameObject.SetActive(true);
        Right_Joint_Part.gameObject.SetActive(true);
        */
    }

    public virtual void OnMouseExit()
    {
        /*
         * 부품별로 다르게 해주세요.
        Forward_Joint_Part.gameObject.SetActive(false);
        Back_Joint_Part.gameObject.SetActive(false);
        Left_Joint_Part.gameObject.SetActive(false);
        Right_Joint_Part.gameObject.SetActive(false);
        */
    }

    public override void OnMouseUpAsButton()
    {
        isDraging = false;
        if (isConnect)
        transform.position = Connected_Joint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isConnect == false && isDraging == true)
        {
            if (collision.CompareTag("Parent_Joint"))
            {
                this.gameObject.transform.parent = collision.gameObject.transform;
                Parent = collision.gameObject.transform.parent.gameObject;
                Connected_Joint = collision.gameObject;
                isConnect = true;

                GameManager.Instance.Joint_Part.Add(gameObject);
                GameManager.Instance.connected_Moudule_Count++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Parent_Joint"))
        {
            this.gameObject.transform.parent = null;
            Parent = null;
            Connected_Joint = null;
            isConnect = false;
            GameManager.Instance.Joint_Part.Remove(gameObject);
            GameManager.Instance.connected_Moudule_Count--;
        }
    }
}
