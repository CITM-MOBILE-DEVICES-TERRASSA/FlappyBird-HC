using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IPlayerInput
{
    public bool GetFlapInput()
    {
        return Input.GetMouseButtonDown(0); // Usa la tecla Espacio para aletear
    }
}