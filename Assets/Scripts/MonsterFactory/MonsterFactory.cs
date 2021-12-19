using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : AbstractEnemyFactory
{
    public MonsterFactory()
    {
    }
    
    public override GameObject CreateEnemy()
    {
        var enemyObject = Resources.Load<GameObject>("Enemies/Enemy1");
        return enemyObject;
    }
}
