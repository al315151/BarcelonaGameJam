﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public virtual void HightLight()
    {

    }

    public abstract void Interact();
}
