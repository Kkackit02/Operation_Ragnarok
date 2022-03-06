using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public List<GameObject> Joint_Part;
    public GameObject MainShip_Object;
    public GameObject GameOver;
    public Ship_Module MainShip_Module_Script;
    public Slider HP_Slider;
    public int connected_Moudule_Count = 0;
    public Rigidbody2D Ship_Rd;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);    
        }

    }

    public void UpdateHP_UI(float value)
    {
        HP_Slider.value = value;
    }
    public void EndGame()
    {

        StartCoroutine(EndGameTimer());
        GameOver.gameObject.SetActive(true);
    }
    private IEnumerator EndGameTimer()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
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
