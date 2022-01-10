using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public bool debugOn;
    [SerializeField] private Transform spawnPoint;
    private AbstractEnemyFactory _factory;

    public void SpawnMonster()
    {
        if (debugOn) Debug.Log("SpawnMonster");
        _factory = new MonsterFactory();//component
        GameObject enemy = _factory.CreateEnemy();
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        if (debugOn) Debug.Log("monster instantiated!");
        //TO DO:
        //Make rules for what enemies should get created
        //and call coresponding methods from _factory.
        //?This MonsterSpawner can get told from GameManager what enemies to spawn.
    }
}
