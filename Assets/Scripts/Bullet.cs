using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] TowerData _towerData;
    private int _damageValue;
    public Vector3 targetPosition;
    
    public void SetDamageValue(int pValue)
    {
        _damageValue = pValue;
    }
    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, _towerData.bulletSpeed);
    }
    //DETECT ENEMY COLLIDER:
    //Tell it it got hit and pass the damage value, destroy bullet
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_towerData.enemyTag))
        {
            other.GetComponent<AbstractEnemy>().TakeDamage(_damageValue);
            Destroy(this.gameObject);
        }
    }
}
