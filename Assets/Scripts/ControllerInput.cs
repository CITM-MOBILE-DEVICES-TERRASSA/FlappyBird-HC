using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : IPlayerInput
{
    public bool GetFlapInput()
    {
        return Input.GetButtonDown("Fire1"); // Usa el botón "Fire1" para aletear en el controlador
    }
}
