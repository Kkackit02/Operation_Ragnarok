using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject Player;

    private float player_Relative_Distance = 0;
    private float player_Relative_Angle = 0;
    private float AI_Hp = 100f;

    public AIData aiData;

    public List<Attack_Module> Attack_Module_List;
    public List<Boost_Module> Boost_Module_List;


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



    enum AiState
    { 
        Idle,
        Chase,
        Attack,
        Runaway,
        Die
    }

    AiState aiState = AiState.Idle;
    void Start()
    {
        Player = GameManager.Instance.MainShip_Object;
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_Player_Data();
        Update_State();
        Func_State();


    }
 

    public void Update_Player_Data()
    {
        player_Relative_Distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
        player_Relative_Angle = GetAngle(transform.position, Player.transform.position) + 270;
    }

    public void Update_State()
    {
        if (AI_Hp >= 50f)
        {
            if (player_Relative_Distance >= 60f)
            {
                Change_State(0);
            }
            else if (player_Relative_Distance < 60f)
            {
                if (player_Relative_Distance <= 40f)
                {
                    Change_State(1);
                }
                else
                {
                    Change_State(2);
                }
            }
        }
        else
        {
            Change_State(3);
            if (AI_Hp <= 0)
            {
                Change_State(4);
            }
        }
    }

    public void Change_State(int value)
    {
        if(value == 0)
        {
            if(aiState == AiState.Idle)
            { 
                //동일(Stay) 구간
            }
            else
            {
                for (int i = 0; i < Attack_Module_List.Count; i++)
                {
                    Attack_Module_List[i].attack_State = Attack_Module.Attack_State.Stop;
                }
                for (int i = 0; i < Boost_Module_List.Count; i++)
                {
                    Boost_Module_List[i].z_Dir = Boost_Module.Z_DirState.Stop;
                }
                for (int i = 0; i < Boost_Module_List.Count; i++)
                {
                    Boost_Module_List[i].y_Dir = Boost_Module.Y_DirState.Stop;
                }
                aiState = AiState.Idle;
                //진입(Enter) 구간
            }
        }
        else if (value == 1)
        {
            if (aiState == AiState.Chase)
            {
                //동일(Stay) 구간
            }
            else
            {
                //탈출(Exit) 구간
                aiState = AiState.Chase;
                //진입(Enter) 구간
            }
        }
        else if (value == 2)
        {
            if (aiState == AiState.Attack)
            {
                //동일(Stay) 구간
            }
            else
            {
                //탈출(Exit) 구간
                aiState = AiState.Attack;
                //진입(Enter) 구간
            }
        }
        else if (value == 3)
        {
            if (aiState == AiState.Runaway)
            {
                //동일(Stay) 구간
            }
            else
            {
                //탈출(Exit) 구간
                aiState = AiState.Runaway;
                //진입(Enter) 구간
            }
        }
        else if (value == 4)
        {
            if (aiState == AiState.Die)
            {
                //동일(Stay) 구간
            }
            else
            {
                //탈출(Exit) 구간
                aiState = AiState.Die;
                //진입(Enter) 구간
            }
        }

    }

    public void Func_State()
    {
        switch (aiState)
        {
            case AiState.Idle:
                
                break;

            case AiState.Chase:
                Debug.Log("Function Chase");
                Debug.Log(transform.rotation.eulerAngles.z);
                if(player_Relative_Angle > transform.rotation.eulerAngles.z + 30f)
                {
                    Signal_Angle_Boost(1);
                }
                else if(player_Relative_Angle < transform.rotation.eulerAngles.z - 30f)
                {
                    Signal_Angle_Boost(2);
                }
                else
                {
                    Signal_Angle_Boost(0);
                }

                Signal_Drive_Boost(1);
                break;
            case AiState.Attack:
                Signal_Attack(1);
                
                if (player_Relative_Angle > transform.rotation.eulerAngles.z + 40f)
                {
                    Signal_Angle_Boost(1);
                }
                else if (player_Relative_Angle < transform.rotation.eulerAngles.z - 40f)
                {
                    Signal_Angle_Boost(2);
                }
                else
                {
                    Signal_Angle_Boost(0);
                }

                if(player_Relative_Distance < 25f)
                {
                    Signal_Drive_Boost(2);
                }
                else if( player_Relative_Distance > 30f)
                {
                    Signal_Drive_Boost(1);
                }
                else
                {
                    Signal_Drive_Boost(0);
                }
                break;

            case AiState.Runaway:
                Signal_Attack(1);
                if (player_Relative_Angle+180f > 10f)
                {
                    Signal_Angle_Boost(1);
                }
                else if (player_Relative_Angle+180f < 10f)
                {
                    Signal_Angle_Boost(2);
                }
                break;

            case AiState.Die:
                Signal_Attack(0);
                Signal_Angle_Boost(0);
                Signal_Drive_Boost(0);
                break;
        }

    }

    public float GetAngle(Vector2 vStart, Vector2 vEnd)
    {        //-180~ 180 dgree return
        Vector3 v = vEnd - vStart;

        return (Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg);
    }

    private void Signal_Angle_Boost(int dir)
    {
        if (dir == 0)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].z_Dir = Boost_Module.Z_DirState.Stop;
            }
        }
        else if (dir == 1)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].z_Dir = Boost_Module.Z_DirState.Left;
            }
        }
        else if (dir == 2)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].z_Dir = Boost_Module.Z_DirState.Right;
            }
        }
    }

    private void Signal_Drive_Boost(int dir)
    {
        if (dir == 0)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].y_Dir = Boost_Module.Y_DirState.Stop;
            }
        }
        else if (dir == 1)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].y_Dir = Boost_Module.Y_DirState.Forward;
            }
        }
        else if (dir == 2)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Boost_Module_List[i].y_Dir = Boost_Module.Y_DirState.Back;
            }
        }
    }

    private void Signal_Attack(int dir)
    {
        if (dir == 0)
        {
            for (int i = 0; i < Attack_Module_List.Count; i++)
            {
                Attack_Module_List[i].attack_State = Attack_Module.Attack_State.Stop;
            }
        }
        else if (dir == 1)
        {
            for (int i = 0; i < Boost_Module_List.Count; i++)
            {
                Attack_Module_List[i].attack_State = Attack_Module.Attack_State.Attack;
            }
        }
    }

}
