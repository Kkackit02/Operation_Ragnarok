using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float scroll_Speed = 10.0f;

    private CinemachineVirtualCamera thisCamera;


    void Start()
    {
        thisCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * scroll_Speed;
        Debug.Log(scroll);
        if(thisCamera.m_Lens.OrthographicSize <= 10.0 && scroll > 0)
        {
            thisCamera.m_Lens.OrthographicSize = 10.0f;
        }

        else if(thisCamera.m_Lens.OrthographicSize >= 60.0f && scroll < 0)
        {
            thisCamera.m_Lens.OrthographicSize = 60.0f;
        }

        else
        {
            thisCamera.m_Lens.OrthographicSize -= scroll;
        }


    }
}
