using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableBase : MonoBehaviour, IActivatable
{
    protected bool _isActivated = false;

    public event EventHandler Activated;
    public event EventHandler Deactivated;

    public virtual void Activate()
    {
        _isActivated = true;
        TriggerActivatedEvent();
    }

    public virtual void Deactivate()
    {
        _isActivated = false;
        TriggerDeactivatedEvent();
    }

    public virtual bool IsActivated()
    {
        return _isActivated;
    }

    private void TriggerActivatedEvent()
    {
        var handler = Activated;
        if (handler != null)
            handler(this, null);
    }

    private void TriggerDeactivatedEvent()
    {
        var handler = Deactivated;
        if (handler != null)
            handler(this, null);
    }
}
