using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<GameObject> Joint_Part;
    public int connected_Moudule_Count = 0;
    public void Display_Joint()
    {
        for(int i = 0; i < connected_Moudule_Count; i++)
        {
            if(Joint_Part[i] != null)
            {
                Joint_Part[i].GetComponent<Extension_Module>().Display_Joint();
            }
        }
    }

    public void Blind_Joint()
    {
        for (int i = 0; i < connected_Moudule_Count; i++)
        {
            if (Joint_Part[i] != null)
            {
                Joint_Part[i].GetComponent<Extension_Module>().Blind_Joint();
            }
        }
    }
}
