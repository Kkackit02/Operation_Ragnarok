using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Module : Module
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;
    public bool isDrive = false;
    public Rigidbody2D rd;
    public float boostPower = 5f;
    void Start()
    {
        isBoost = true;
        Back_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        rd = GetComponent<Rigidbody2D>();
        Blind_Joint();
        OFF_Joint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDrive == true)
        {
            rd.AddRelativeForce(Vector2.up * boostPower);
        }
    }

    public override void OnMouseOver()
    {
        GameManager.Instance.Display_Ship_Joint();
        //OFF_Joint();
    }

    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Ship_Joint();
        //ON_Joint();
    }
}
