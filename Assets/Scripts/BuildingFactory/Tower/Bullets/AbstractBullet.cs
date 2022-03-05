using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour
{
    [SerializeField] public TowerData _towerData;
    //DETECT ENEMY COLLIDER:
    //Tell it it got hit and pass the damage value, destroy bullet
    

    protected abstract void CreateAttack(Collider pTarget);
}
