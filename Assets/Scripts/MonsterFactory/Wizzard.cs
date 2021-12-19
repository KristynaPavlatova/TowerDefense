using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Wizzard : AbstractEnemy, IMortal, IMoving
{
    public MonsterData monsterData;
    public void Start()
    {
        Debug.Log("Wizzard created!");
    }

    private void Update()
    {
        
    }

    public void Death()
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        throw new NotImplementedException();
    }
}
