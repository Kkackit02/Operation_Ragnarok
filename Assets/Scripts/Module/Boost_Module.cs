using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Module : Module
{
    public bool isConnected = false;
    public Ship_Controller Connected_Ship;
    private Enemy_AI enemy_AI_Script;
    public bool isDrive = false;
    private float boostPower = 20f;
    private float reverseBoostPower = 10f;
    private Rigidbody2D Ship_rd;



    public enum Y_DirState
    {
        Stop,
        Forward,
        Back
    }

    public enum X_DirState
    {
        Stop,
        Left,
        Right
    }

    public enum Z_DirState // 각도
    {
        Stop,
        Left,
        Right
    }

    public Y_DirState y_Dir = Y_DirState.Stop;
    public X_DirState x_Dir = X_DirState.Stop;
    public Z_DirState z_Dir = Z_DirState.Stop;




    void Start()
    {
        if(isPlayer)
        {
            Ship_rd = GameManager.Instance.MainShip_Object.GetComponent<Rigidbody2D>();
        }
        else
        {
            // Ship_rd에 직접 지정해줘야합니다.
        }

        //Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Blind_Joint();
        OFF_Joint();
        boostPower = module_Data.BoostPower;
        reverseBoostPower = module_Data.ReverseBoostPower;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPlayer)
        {
            if (DirCode == 1)//0 = null, 1 = forward, 2 = back, 3 = left, 4 = right
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.down * boostPower);
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.up * reverseBoostPower);
                }

            }
            else if (DirCode == 2)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.up * boostPower);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.down * reverseBoostPower);
                }

            }

            if (DirCode == 3)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.right * boostPower);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.left * reverseBoostPower);
                }

                if (Input.GetKey(KeyCode.E))
                {
                    Ship_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * boostPower);
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    Ship_rd.AddTorque(new Vector3(1, 0, 0).magnitude * reverseBoostPower);
                }
            }
            else if (DirCode == 4)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.left * boostPower);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.right * reverseBoostPower);
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    Ship_rd.AddTorque(new Vector3(1, 0, 0).magnitude * boostPower);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Ship_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * reverseBoostPower);
                }
            }

            if (Input.GetKey(KeyCode.Q))
            {
                Ship_rd.AddTorque((new Vector3(0.5f, 0, 0).magnitude) * boostPower);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                Ship_rd.AddTorque(-(new Vector3(0.5f, 0, 0).magnitude) * boostPower);
            }
        }
        
        else
        {           
            if (DirCode == 1)//0 = null, 1 = forward, 2 = back, 3 = left, 4 = right
            {
                switch (y_Dir)
                {
                    case Y_DirState.Stop:
                        break;
                    case Y_DirState.Forward:
                        Ship_rd.AddRelativeForce(Vector2.up * reverseBoostPower);
                        break;
                    case Y_DirState.Back:
                        Ship_rd.AddRelativeForce(Vector2.down * boostPower);
                        break;
                }
            }
            else if (DirCode == 2)
            {
                switch (y_Dir)
                {
                    case Y_DirState.Stop:
                        break;
                    case Y_DirState.Forward:
                        Ship_rd.AddRelativeForce(Vector2.up * boostPower);
                        break;
                    case Y_DirState.Back:
                        Ship_rd.AddRelativeForce(Vector2.down * reverseBoostPower);
                        break;
                }

            }

            if (DirCode == 3)
            {
                switch (x_Dir)
                {
                    case X_DirState.Stop:
                        break;
                    case X_DirState.Left:
                        Ship_rd.AddRelativeForce(Vector2.left * reverseBoostPower);
                        break;
                    case X_DirState.Right:
                        Ship_rd.AddRelativeForce(Vector2.right * boostPower);
                        break;
                }

                switch (z_Dir)
                {
                    case Z_DirState.Stop:
                        break;
                    case Z_DirState.Left:
                        Ship_rd.AddTorque(new Vector3(1, 0, 0).magnitude * reverseBoostPower);
                        break;
                    case Z_DirState.Right:
                        Ship_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * boostPower);
                        break;
                }

            }
            else if (DirCode == 4)
            {
                switch (x_Dir)
                {
                    case X_DirState.Stop:
                        break;
                    case X_DirState.Left:
                        Ship_rd.AddRelativeForce(Vector2.left * reverseBoostPower);
                        break;
                    case X_DirState.Right:
                        Ship_rd.AddRelativeForce(Vector2.right * boostPower);
                        break;
                }

                switch (z_Dir)
                {
                    case Z_DirState.Stop:
                        break;
                    case Z_DirState.Left:
                        Ship_rd.AddTorque(new Vector3(1, 0, 0).magnitude * boostPower);
                        break;
                    case Z_DirState.Right:
                        Ship_rd.AddTorque(-(new Vector3(1, 0, 0).magnitude) * reverseBoostPower);
                        break;
                }
            }
        }
    }


    public override void OnMouseOver()
    {
        if(isPlayer)
        GameManager.Instance.Display_Ship_Joint();
        //OFF_Joint();
    }

    public override void OnMouseExit()
    {
        if(isPlayer)
        GameManager.Instance.Blind_Ship_Joint();
        //ON_Joint();
    }
}
