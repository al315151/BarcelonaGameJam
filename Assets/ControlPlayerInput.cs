using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerInput : MonoBehaviour
{
    public void EnableInput()
    {
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController.canInput = true;
    }

    public void DisableInput()
    {
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController.canInput = false;
    }
}
