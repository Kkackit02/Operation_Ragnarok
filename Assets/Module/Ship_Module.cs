using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Module : Module
{
    void Start()
    {
        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        Blind_Joint();
   
    }
    public override void OnMouseOver()
    {
        GameManager.Instance.Display_Ship_Joint();
        //ON_Joint();
    }

    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Ship_Joint();
        //OFF_Joint();
    }

   

}
