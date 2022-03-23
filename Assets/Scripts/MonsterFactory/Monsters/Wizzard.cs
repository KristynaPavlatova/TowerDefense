using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizzard : AbstractEnemy, IMoving
{
    public bool debugOn;
    [Space(10)]
    public MonsterData monsterData;

    public void Start()
    {
        if(debugOn) Debug.Log("Wizzard created!");
        this.InitializeEnemy(monsterData.monsterHealth, monsterData.monsterCarriedMoney, monsterData.monsterSpeed, monsterData.stoppingDistance);
        if (debugOn) Debug.Log($"HP = {this.health}, Money = {this.carriedMoney}, Speed = {this.agent.speed}");
    }

    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (Vector3.Distance(this.transform.position, monsterData.goalPosition) > this.agent.stoppingDistance)
        {
            this.agent.SetDestination(monsterData.goalPosition);
        }
        else
        {
            this.agent.isStopped = true;
            if (debugOn) Debug.Log("Wizzard reached goal destination!");
        }
    }
}
