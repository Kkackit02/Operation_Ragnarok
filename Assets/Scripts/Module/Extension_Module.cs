using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extension_Module : Module
{
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = 0.6f;
        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        Blind_Joint();
        OFF_Joint();
    }

    public override void Change_Dir(GameObject Joint)
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

    public override void OnMouseOver()
    {
        GameManager.Instance.Display_Ship_Joint();
        OFF_Joint();
    }

    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Ship_Joint();
        ON_Joint();
    }

}
