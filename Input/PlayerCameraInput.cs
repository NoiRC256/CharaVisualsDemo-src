using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraInput : CameraInput
{
    public static PlayerCameraInput Instance;

    private void Awake()
    {
        Instance = this;
    }

    public override Vector2 GetAxisInput()
    {
        if (acceptInput == false) return Vector2.zero;

        float x_input = Input.GetAxis("Mouse X");
        float y_input = Input.GetAxis("Mouse Y");
        Vector2 axis_input = new Vector2(x_input, y_input);

        return axis_input;
    }
}
