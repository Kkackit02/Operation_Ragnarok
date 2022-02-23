using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Module : Module
{
    private float boostPower = 10.0f;
    public Rigidbody2D Player_rd;

    public float ship_Mass = 2f;
    public float ship_Drag = 0.4f;
    public float ship_Angular_Drag = 0.5f;


    void Start()
    {
        Player_rd = GetComponent<Rigidbody2D>();
        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        Blind_Joint();
    }


    public void AddMass(float mass)
    {
        ship_Mass += mass;
        ship_Drag = ship_Mass / 9f;
        ship_Angular_Drag = ship_Mass / 2f;

        Player_rd.mass = ship_Mass;
        Player_rd.drag = ship_Drag;
        Player_rd.angularDrag = ship_Angular_Drag;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Player_rd.AddRelativeForce(Vector2.down * boostPower);
            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Player_rd.AddRelativeForce(Vector2.up * boostPower);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player_rd.AddRelativeForce(Vector2.right * boostPower);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player_rd.AddRelativeForce(Vector2.left * boostPower);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            Player_rd.AddTorque(0.05f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Player_rd.AddTorque(-0.05f);
        }
    }

    public override void OnMouseOver()
    {
        GameManager.Instance.Display_Ship_Joint();
        //ON_Joint();
    }
    public override void OnMouseDrag()
    {
        GameManager.Instance.Display_Ship_Joint();

    }
    public override void OnMouseExit()
    {
        GameManager.Instance.Blind_Ship_Joint();
        //OFF_Joint();
    }

   

}
