using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : AbstractAttackFactory
{
    public override GameObject CreateRegularAttack()
    {
        var bullet = Resources.Load<GameObject>("Bullets/BulletRegular");

        if (bullet == null)
        {
            Debug.LogError($"{this.name}: Could not find BulletRegular in Bullets!");
            return null; 
        }
        else return bullet;
    }
    public override GameObject CreateAreaOfAttack()
    {
        var bullet = Resources.Load<GameObject>("Bullets/BulletAreaOf");
        if (bullet == null)
        {
            Debug.LogError($"{this.name}: Could not find BulletAreaOf in Bullets!");
            return null;
        }
        else return bullet;
    }
    public override GameObject CreateDebuffAttack()
    {
        var bullet = Resources.Load<GameObject>("Bullets/BulletDebuff");
        if (bullet == null)
        {
            Debug.LogError($"{this.name}: Could not find BulletDebuff in Bullets!");
            return null;
        }
        else return bullet;
    }

}
