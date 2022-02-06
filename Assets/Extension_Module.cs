using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extension_Module : Module
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
        GameManager.Instance.Display_Joint();
    }

    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Joint();
    }

    public void Display_Joint()
    {
        Forward_Joint_Part.gameObject.SetActive(true);
        Back_Joint_Part.gameObject.SetActive(true);
        Left_Joint_Part.gameObject.SetActive(true);
        Right_Joint_Part.gameObject.SetActive(true);
    }

    public void Blind_Joint()
    {
        Forward_Joint_Part.gameObject.SetActive(false);
        Back_Joint_Part.gameObject.SetActive(false);
        Left_Joint_Part.gameObject.SetActive(false);
        Right_Joint_Part.gameObject.SetActive(false);
    }

}
