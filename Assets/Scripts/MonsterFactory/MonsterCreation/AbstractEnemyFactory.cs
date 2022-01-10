using UnityEngine;

public abstract class AbstractEnemyFactory : MonoBehaviour
{
    public abstract GameObject CreateEnemy();//returning "Abstract enemy" but here it is an obj
}
