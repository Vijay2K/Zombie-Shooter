using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public FixedButton JumpButton;
    public FixedTouchField touchField;
    public FixedJoystick joyStick;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var FPS = GetComponent<RigidbodyFirstPersonController>();

        FPS.RunAxis = joyStick.Direction;
        FPS.JumpAxis = JumpButton.Pressed;

        FPS.mouseLook.LookAxis = touchField.TouchDist;
       
    }
}
