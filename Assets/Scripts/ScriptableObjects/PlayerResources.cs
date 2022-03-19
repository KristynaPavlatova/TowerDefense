using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerResources", menuName = "Scripts/ScriptableObjects/PlayerResources", order = 3)]
public class PlayerResources : ScriptableObject
{
    public int playerMaxHealth;
    public int playerOneEnemyHealthDescrease;

    [Space(10)] public int playerStarGold;
}
