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
    [Tooltip("How much damage is any bullet dealing. finalBulletDamage = towerLevel * bulletDamageGeneral")]
    public int bulletDamageGeneral;
    public float bulletSpeed;
    [Tooltip("Deley between when tower detects an enemy and actually starts firing bullets at the target.")]
    public float towerAttackDelay;

    [Space(10)]
    [Header("Regular attack:")]
    public float attackRadiusRegular;
    public float attackFrequencyRegular;

    [Space(10)]
    [Header("AreaOf attack:")]
    public float attackRadiusAreaOf;
    public float attackFrequencyAreaOf;

    [Space(10)]
    [Header("Debuff attack:")]
    public float attackRadiusDebuff;
    public float attackFrequencyDebuff;

}
