using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAreaOf : AbstractBullet
{
    public Vector3 targetPosition;

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, targetPosition, _towerData.bulletSpeed);
    }
    public float GetAreaOfEffectRadius => _towerData.bulletAreaOfRadius;
    protected override void CreateAttack(Collider pTarget)
    {
        Collider[] foundColliders = Physics.OverlapSphere(transform.position, _towerData.bulletAreaOfRadius, _towerData.enemyLayerMask);
        if (foundColliders.Length != 0)
        {
            //Damage all colliders
            foreach(Collider target in foundColliders)
            {
                target.GetComponent<AbstractEnemy>().TakeDamage(_towerData.bulletDamageAreaOf);
            }
        }
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
