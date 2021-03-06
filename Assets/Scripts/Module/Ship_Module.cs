using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Module : Module
{
    private float boostPower = 20.0f;
    public Rigidbody2D Ship_rd;
    private bool isDie = false;

    public float ship_Mass = 2f;
    public float ship_Drag = 0.4f;
    public float ship_Angular_Drag = 0.5f;
    //public new GameObject[] DestroyEffect;

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

    public enum Z_DirState // ????
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
        Decomposite_Sound = SoundManager.Instance.Decomposite;
        Composite_Sound = SoundManager.Instance.Composite;
        BulletHit_Sound = SoundManager.Instance.BulletHit;
        myAudio = GetComponent<AudioSource>();
        myAudio.volume = 0.6f;
        Ship_rd = GetComponent<Rigidbody2D>();
        Forward_Joint_Part = gameObject.transform.GetChild(0).gameObject;
        Back_Joint_Part = gameObject.transform.GetChild(1).gameObject;
        Left_Joint_Part = gameObject.transform.GetChild(2).gameObject;
        Right_Joint_Part = gameObject.transform.GetChild(3).gameObject;
        Blind_Joint();
    }


    public void AddMass(float mass)
    {
        ship_Mass += mass;
        ship_Drag = ship_Mass / 8f;
        ship_Angular_Drag = ship_Mass / 1.5f;

        Ship_rd.mass = ship_Mass;
        Ship_rd.drag = ship_Drag;
        Ship_rd.angularDrag = ship_Angular_Drag;
    }

    protected override void Reset_Flag()
    {
        y_Dir = Y_DirState.Stop;
        x_Dir = X_DirState.Stop;
        z_Dir = Z_DirState.Stop;
    }
    public void FixedUpdate()
    {
        if (isDie == false)
        {
            if (isPlayer == true)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.down * boostPower);
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.up * boostPower);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.right * boostPower);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Ship_rd.AddRelativeForce(Vector2.left * boostPower);
                }

                if (Input.GetKey(KeyCode.Q))
                {
                    Ship_rd.AddTorque(2f);
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Ship_rd.AddTorque(-2f);
                }
            }
            else
            {
                switch (y_Dir)
                {
                    case Y_DirState.Stop:
                        break;
                    case Y_DirState.Forward:
                        Ship_rd.AddRelativeForce(Vector2.up * boostPower);
                        break;
                    case Y_DirState.Back:
                        Ship_rd.AddRelativeForce(Vector2.down * boostPower);
                        break;
                }

                switch (x_Dir)
                {
                    case X_DirState.Stop:
                        break;
                    case X_DirState.Left:
                        Ship_rd.AddRelativeForce(Vector2.left * boostPower);
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
                        Ship_rd.AddTorque(0.05f);
                        break;
                    case Z_DirState.Right:
                        Ship_rd.AddTorque(-0.05f);
                        break;
                }
            }
        }

        
        
    }

    public override void Destroy_Module()
    {
        if(isDestroy == false)
        {
            Decompose_Module(true);
            myAudio.PlayOneShot(SoundManager.Instance.DestroyShip);
            int a = Random.Range(0, 2);
            GameObject A = Instantiate(DestroyEffect, this.gameObject.transform);
            A.transform.parent = null;
            isDestroy = true;

            if (isPlayer == true)
            {
                GameManager.Instance.EndGame();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        

        
    }

    public override void OnMouseOver()
    {
        if(isPlayer)
        GameManager.Instance.Display_Ship_Joint();
        //ON_Joint();
    }
    public override void OnMouseDrag()
    {
        if(isPlayer)
        GameManager.Instance.Display_Ship_Joint();

    }
    public override void OnMouseExit()
    {
        if(isPlayer)
        GameManager.Instance.Blind_Ship_Joint();
        //OFF_Joint();
    }

    public override void Update_Module_HP(float value)
    {
        Module_Hp -= value;
        myAudio.PlayOneShot(BulletHit_Sound);
        if(isPlayer == true)
        {
            GameManager.Instance.UpdateHP_UI(Module_Hp);
        }
        if (Module_Hp <= 0)
        {
            isDie = true;
            Destroy_Module();
        }

    }

}
