using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scripts/ScriptableObjects/MonsterData", order = 1)]
public class MonsterData : ScriptableObject
{
    //collection of models so factory can just get it from here
    //public GameObject wizzardModel;

    public Vector3 goalPosition;

    [Space(10)]
    public int monsterHealth;
    public int monsterCarriedMoney;
    public float monsterSpeed;
    public float stoppingDistance;
}
