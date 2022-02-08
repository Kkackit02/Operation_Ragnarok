using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    protected bool isDraging = false;
    protected float distance = 10.0f;
    public virtual void OnMouseDrag()
    {
        Debug.Log("Draging");
        isDraging = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, distance);

        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
    
    public virtual void OnMouseUpAsButton()
    {
        isDraging = false;
    }

}
