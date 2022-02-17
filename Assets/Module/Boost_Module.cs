using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Module : Module
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;
    public bool isDrive = false;
    public Rigidbody2D rd;
    public float boostPower = 20f;
    private float reverseBoostPower = 10f;
    private Rigidbody2D Player_rd;
    void Start()
    {
        Player_rd = GameManager.Instance.MainShip_Object.GetComponent<Rigidbody2D>();
        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        rd = GetComponent<Rigidbody2D>();
        Blind_Joint();
        OFF_Joint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (DirCode == 1)//0 = null, 1 = forward, 2 = back, 3 = left, 4 = right
        {
            if(Input.GetKey(KeyCode.DownArrow))
            {
                Player_rd.AddForce(Vector3.down * boostPower);
            }
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                Player_rd.AddForce(Vector3.up * reverseBoostPower);
            }
            
        }
        else if (DirCode == 2)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Player_rd.AddForce(Vector3.down * reverseBoostPower);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                Player_rd.AddForce(Vector3.up * boostPower);
            }
            
        }

        if (DirCode == 3 )
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player_rd.AddForce(Vector3.right * boostPower);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player_rd.AddForce(Vector3.left * reverseBoostPower);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                Player_rd.AddTorque(new Vector3(1, 0, 0).magnitude * reverseBoostPower);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Player_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * boostPower);
            }
        }
        else if (DirCode == 4)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player_rd.AddForce(Vector3.right * reverseBoostPower);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player_rd.AddForce(Vector3.left * boostPower);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                Player_rd.AddTorque(new Vector3(1, 0, 0).magnitude * boostPower);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Player_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * reverseBoostPower);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Player_rd.AddTorque((new Vector3(0.5f, 0, 0).magnitude) * boostPower);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Player_rd.AddTorque(-(new Vector3(0.5f, 0, 0).magnitude) * boostPower);
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
