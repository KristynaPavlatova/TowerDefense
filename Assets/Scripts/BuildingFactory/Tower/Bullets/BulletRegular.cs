using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRegular : AbstractBullet
{
    public Vector3 targetPosition;

    private void FixedUpdate()
    {
        Debug.Log($"target pos = {targetPosition}");
        Debug.Log($"_towerData.bulletSpeed = {_towerData.bulletSpeed}");

        if (targetPosition == Vector3.zero)
        {
            Debug.LogError($"{this.name}: Bullet has no targetPosition!");
        }
        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, _towerData.bulletSpeed);
    }
    protected override void CreateAttack(Collider pTarget)
    {
        pTarget.GetComponent<AbstractEnemy>().TakeDamage(_towerData.bulletDamageRegular);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_towerData.enemyTag))
        {
            CreateAttack(other);
            Destroy(this.gameObject);
        }
    }
}
