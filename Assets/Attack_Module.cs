using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Module : MonoBehaviour
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;
    public List<GameObject> Muzzle_Part;
    void Start()
    {
            
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
