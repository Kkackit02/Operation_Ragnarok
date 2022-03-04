using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<GameObject> Joint_Part;
    public GameObject MainShip_Object;
    public Ship_Module MainShip_Module_Script;
    public int connected_Moudule_Count = 0;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);    
        }

    }
    public void Display_Ship_Joint()
    {
        for(int i = 0; i < connected_Moudule_Count; i++)
        {
            if(Joint_Part[i] != null)
            {
                if(Joint_Part[i].GetComponent<Extension_Module>() != null)
                {
                    Joint_Part[i].GetComponent<Extension_Module>().Display_Joint();
                }
                if (Joint_Part[i].GetComponent<Ship_Module>() != null)
                {
                    Joint_Part[i].GetComponent<Ship_Module>().Display_Joint();
                }

            }
        }
    }

    public void Blind_Ship_Joint()
    {
        for (int i = 0; i < connected_Moudule_Count; i++)
        {
            if (Joint_Part[i] != null)
            {
                if (Joint_Part[i].GetComponent<Extension_Module>() != null)
                {
                    Joint_Part[i].GetComponent<Extension_Module>().Blind_Joint();
                }
                else if (Joint_Part[i].GetComponent<Ship_Module>() != null)
                {
                    Joint_Part[i].GetComponent<Ship_Module>().Blind_Joint();
                }
                
            }
            
        }
    }
}
