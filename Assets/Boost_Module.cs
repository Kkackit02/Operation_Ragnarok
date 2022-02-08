using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Module : MonoBehaviour
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnected == true)
        {
            Connected_Ship.Boost_Module.Add(this);
        }
        else
        {
            Connected_Ship.Boost_Module.Remove(this);
        }
    }
}
