using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ModuleData", menuName = "Scriptable Object/ModuleData", order = int.MaxValue)]

public class PlayerCharacterData : ScriptableObject
{
    [SerializeField]
    private int moduleCode;
    public int ModuleCode { get { return moduleCode; } }

}
