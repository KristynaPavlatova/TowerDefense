using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Scripts/ScriptableObjects/TowerData", order = 2)]
public class TowerData : ScriptableObject
{
    public string enemyTag = "Enemy";
    public LayerMask enemyLayerMask;
    public bool showDebugAttackLine = true;
    public Color debugColor = Color.cyan;
    [Tooltip("To ensure detecting target leaving attack radius work correctly, give a small value. (0.3f)")]
    public float attackRadiusToleranceValue = 0.3f;

    [Space(10)]
    public float bulletSpeed;//For each attack type
    [Tooltip("Deley between when tower detects an enemy and actually starts firing bullets at the target.")]
    public float towerAttackDelay;

    [Space(10)]
    [Header("Regular attack:")]
    public float attackRadiusRegular;
    public float attackFrequencyRegular;
    public int bulletDamageRegular;

    [Space(10)]
    [Header("AreaOf attack:")]
    public float attackRadiusAreaOf;
    public float attackFrequencyAreaOf;
    public int bulletDamageAreaOf;

    public float bulletAreaOfRadius;

    [Space(10)]
    [Header("Debuff attack:")]
    public float attackRadiusDebuff;
    public float attackFrequencyDebuff;
    public int bulletDamageDebuff;

    //TO DO:
    [Space(10)]
    [Header("Tower upgrades:")]
    [Tooltip("Price for building a new tower.")]
    public int towerBasePrice;
    [Tooltip("By how much upgrading a tower costs more with each tower level? (this amount * towerLevel = upgrade cost)")]
    public int towerUpgradeCostIncrease;
    [Tooltip("How much gold the player gets if they desctroy level 1 tower. Higher levels will be calculated based on this amount * towerLevel = destroy tower gold return.")]
    public int towerDestroyBaseIncrease;
}
