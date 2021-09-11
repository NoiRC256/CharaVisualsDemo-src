using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraInput : MonoBehaviour
{
    public bool acceptInput = true;

    public abstract Vector2 GetAxisInput();
}
