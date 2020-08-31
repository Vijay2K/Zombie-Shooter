using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{

    private Touch touch = new Touch();
    public Camera cam;

    private float RotX = 0f;
    private float RotY = 0f;
    private Vector3 OrginalRot;

    public float RotSpeed = 0.5f;
    public float direction = -1f;


    void Start()
    {
        OrginalRot = cam.transform.eulerAngles;
        RotX = OrginalRot.x;
        RotY = OrginalRot.y;
    }

    void FixedUpdate()
    {
        foreach(Touch _touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                touch = _touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {//swipe
                float X = touch.position.x - _touch.position.x;
                float Y = touch.position.y - _touch.position.y;

                RotX -= Y * Time.deltaTime * RotSpeed * direction;
                RotY += X * Time.deltaTime * RotSpeed * direction;

                cam.transform.eulerAngles = new Vector3(RotX, RotY, 0f); //storing a values 
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touch = new Touch();
            }
        }
    }


}
