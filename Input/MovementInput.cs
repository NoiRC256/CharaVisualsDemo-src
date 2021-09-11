using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementInput : MonoBehaviour
{
    public bool acceptInput = true;

    public abstract bool IsFireKeyDown();
    public abstract bool IsFireKeyHold();
    public abstract bool IsFireKeyUp();
}
