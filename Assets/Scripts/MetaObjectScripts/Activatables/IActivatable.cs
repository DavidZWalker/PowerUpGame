using UnityEngine;
using System.Collections;
using System;

public interface IActivatable
{
    event EventHandler Activated;

    event EventHandler Deactivated;

    void Activate();

    void Deactivate();

    bool IsActivated();
}
