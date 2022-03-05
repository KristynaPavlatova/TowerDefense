using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDebuff : AbstractBullet
{
    public Vector3 targetPosition;

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, _towerData.bulletSpeed);
    }
    protected override void CreateAttack(Collider pTarget)
    {
        throw new System.NotImplementedException();
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
