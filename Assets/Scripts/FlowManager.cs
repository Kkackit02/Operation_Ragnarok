using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowManager : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);

    }
    public void LoadIngame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
