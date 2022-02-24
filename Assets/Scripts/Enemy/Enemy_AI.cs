using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject Player;

    private float player_Distance = 0;
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

    public enum Z_DirState // °¢µµ
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
        Update_Player_Distance();
        Update_State();


    }
 

    public void Update_Player_Distance()
    {
        player_Distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
    }

    public void Update_State()
    {
        if (AI_Hp >= 50f)
        {
            if (player_Distance >= 30f)
            {
                aiState = AiState.Idle;
            }
            else if (player_Distance < 30f)
            {
                if (player_Distance <= 15f)
                {
                    aiState = AiState.Chase;
                }
                else
                {
                    aiState = AiState.Attack;
                }
            }
        }
        else
        {
            aiState = AiState.Runaway;

            if (AI_Hp <= 0)
            {
                aiState = AiState.Die;
            }
        }
    }
}
