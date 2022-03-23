using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : AbstractEnemyFactory
{
    public bool debugOn;
    public MonsterFactory()
    {
    }
    public override GameObject CreateEnemy()
    {
        if(debugOn) Debug.Log("creating monster in factory");
        var enemyObject = Resources.Load<GameObject>("Enemies/Enemy1");//Monster scriptable obj
        if (debugOn) Debug.Log("returning monster from factory");
        return enemyObject;
    }
}
