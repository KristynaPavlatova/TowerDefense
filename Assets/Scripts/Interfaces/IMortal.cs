using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMortal
{
    public abstract void OnDeath();
    public abstract void TakeDamage(int pAmount);
}
