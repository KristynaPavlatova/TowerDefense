using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private AbstractEnemyFactory _factory;

    public void CreateMonster()
    {
        _factory = new MonsterFactory();
        GameObject enemy = _factory.CreateEnemy();
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }
}
