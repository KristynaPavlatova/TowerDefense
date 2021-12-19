using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scripts/ScriptableObjects/MonsterData", order = 1)]
public class MonsterData : ScriptableObject
{
    public GameObject wizzardModel;

    public int monsterHealth;
    public int monsterCarriedMoney;
    public float monsterSpeed;
}
