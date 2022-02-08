using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : Module
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;

    void Start()
    {
        Back_Joint_Part = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isConnected == true)
        {
            Connected_Ship.Attack_Module.Add(this);
        }
        else
        {
            Connected_Ship.Attack_Module.Remove(this);
        }
    }


    
}
