using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ModuleData", menuName = "Scriptable Object/ModuleData", order = int.MaxValue)]

public class ModuleData : ScriptableObject
{
    [SerializeField]
    private int moduleCode; // 0 - extend, 1 - attack, 2 - util
    public int ModuleCode { get { return moduleCode; } }

    [SerializeField]
    private float moduleHp;
    public float ModuleHp { get { return moduleHp; } }

    [SerializeField]
    private float moduleDamage;
    public float ModuleDamage { get { return moduleDamage; } }

    [SerializeField]
    private float attackDalay;
    public float AttackDalay { get { return attackDalay; } }

    [SerializeField]
    private float boostPower;
    public float BoostPower{ get { return boostPower; } }

    [SerializeField]
    private float reverseBoostPower;
    public float ReverseBoostPower { get { return reverseBoostPower; } }

    [SerializeField]
    private float moduleMass;
    public float ModuleMass { get { return moduleMass; } }

}
