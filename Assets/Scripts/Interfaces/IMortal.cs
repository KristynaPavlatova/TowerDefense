using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMortal
{
    public void OnDeath();
    public void TakeDamage(int pAmount);
}
