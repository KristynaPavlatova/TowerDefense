using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damageValue;
    public void SetDamageValue(int pValue)
    {
        _damageValue = pValue;
    }
    private void Update()
    {
        //Move forward. Rotated by the Tower that created the bullet.
    }
    //DETECT ENEMY COLLIDER:
    //Tell it it got hit and pass the damage value, destroy bullet
}
