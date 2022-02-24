using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AiData", menuName = "Scriptable Object/AiData", order = int.MaxValue)]

public class AIData : ScriptableObject
{
    [SerializeField]
    private int aiCode; // 0 - range, 1 - melee, 2 - util
    public int AiCode { get { return AiCode; } }

    [SerializeField]
    private float aiHp;
    public float AiHp { get { return AiHp; } }

}
