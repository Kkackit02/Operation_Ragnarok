using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private float scroll_Speed = 0.5f;

    private CinemachineVirtualCamera thisCamera;


    void Start()
    {
        thisCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll;
        if (Input.GetKey(KeyCode.O))
        {
            scroll = scroll_Speed;
        }
        else if(Input.GetKey(KeyCode.P))
        {
            scroll = -scroll_Speed;
        }
        else
        {
            scroll = 0;
        }

        if(thisCamera.m_Lens.OrthographicSize <= 10.0 && scroll > 0)
        {
            thisCamera.m_Lens.OrthographicSize = 10.0f;
        }

        else if(thisCamera.m_Lens.OrthographicSize >= 200.0f && scroll < 0)
        {
            thisCamera.m_Lens.OrthographicSize = 200.0f;
        }

        else
        {
            thisCamera.m_Lens.OrthographicSize -= scroll;
        }


    }
}
