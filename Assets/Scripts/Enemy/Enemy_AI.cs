using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public GameObject Player;

    private float player_Distance = 0;
    private float AI_Hp = 100f;
    

    

    enum AiState
    { 
        Idle,
        Chase,
        Attack,
        Runaway,
        Die
    }
    
    private StateMachine stateMachine;

    private Dictionary<AiState, IState> dicState = new Dictionary<AiState, IState>();

    void Start()
    {
        Player = GameManager.Instance.MainShip_Object;

        IState idle = new StateIdle();
        IState attack = new StateAttack();
        IState chase = new StateChase();
        IState runAway = new StateRunaway();
        IState die = new StateDie();

        //키입력 등에 따라서 언제나 상태를 꺼내 쓸 수 있게 딕셔너리에 보관
        dicState.Add(AiState.Idle, idle);
        dicState.Add(AiState.Attack, attack);
        dicState.Add(AiState.Chase, chase);
        dicState.Add(AiState.Runaway, runAway);
        dicState.Add(AiState.Die, die);

        //기본상태는 달리기로 설정.
        stateMachine = new StateMachine(idle);
    }

    // Update is called once per frame
    void Update()
    {
        Update_Player_Distance();

        if(AI_Hp >= 50f)
        {
            if (player_Distance >= 30f)
            {
                stateMachine.SetState(dicState[AiState.Idle]);
            }
            else if (player_Distance < 30f)
            {
                if (player_Distance <= 15f)
                {
                    stateMachine.SetState(dicState[AiState.Chase]);
                }
                else
                {
                    stateMachine.SetState(dicState[AiState.Attack]);
                }
            }
        }
        else
        {
            stateMachine.SetState(dicState[AiState.Runaway]);
        }
        
        if(AI_Hp <= 0)
        {
            stateMachine.SetState(dicState[AiState.Die]);
        }

            stateMachine.DoOperateUpdate();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            stateMachine.SetState(dicState[AiState.Die]);
        }
    }

    public void Update_Player_Distance()
    {
        player_Distance = Vector3.Distance(gameObject.transform.position, Player.transform.position);
    }
}
