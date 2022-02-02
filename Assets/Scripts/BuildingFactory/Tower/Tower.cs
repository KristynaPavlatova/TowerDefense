using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletFactory))]
public class Tower : MonoBehaviour
{
    [SerializeField] private bool debugOn = false;
    [Space(10)][SerializeField] private TowerData _towerData;
    private AbstractAttackFactory _attackFactory;
    
    private float _attackRadius = 1;//Just for debbug purpose
    private float _attackFrequency;
    private int _bulletDamageValue;
    [Space(10)][SerializeField] private int _currentTowerLevel;

    public enum AttackType
    {
        Regular = 0,
        AreaOf = 1,
        Debuff = 2
    }
    [SerializeField] private AttackType _attackType = AttackType.Regular;

    private GameObject _target;

    private void Start()
    {
        initializeTower();
    }
    public int GetTowerLevel => _currentTowerLevel;
    public void ChangeTowerAttackType(AttackType pAttackType)
    {
        _attackType = pAttackType;
        initializeTower();
    }
    public float GetAttackRadius => _attackRadius;
    
    //TOWER PROPERTIES:
    private void initializeTower()
    {
        _attackFactory = this.GetComponent<AbstractAttackFactory>();
        Debug.Assert(_attackFactory, $"{this.name}: Has no component of type AbstractAttackFactory! (for example towerFactory)");

        assignDataToTower();
        if(debugOn) Debug.Log($"{this.name}: Tower initialized: attack type = {_attackType}, attack radius = {_attackRadius}, attack frequency = {_attackFrequency}");
    }
    private void assignDataToTower()
    {
        switch (_attackType)
        {
            case AttackType.Regular:
                _attackRadius = _towerData.attackRadiusRegular;
                _attackFrequency = _towerData.attackFrequencyRegular;
                break;
            case AttackType.AreaOf:
                _attackRadius = _towerData.attackRadiusAreaOf;
                _attackFrequency = _towerData.attackFrequencyAreaOf;
                break;
            case AttackType.Debuff:
                _attackRadius = _towerData.attackRadiusDebuff;
                _attackFrequency = _towerData.attackFrequencyDebuff;
                break;
        }
        _bulletDamageValue = _towerData.bulletAttackDamageLevelIncrease * _currentTowerLevel;
        if (debugOn) Debug.Log($"{this.name}: Switched attack type.");
    }
    private void FieldOfViewCheck()
    {
        Collider[] foundColliders = Physics.OverlapSphere(transform.position, _attackRadius, _towerData.enemyLayerMask);
        if(foundColliders.Length != 0)
        {
            _target = foundColliders[0].gameObject;
            if (debugOn) Debug.Log($"{this.name}: Found new target.");
            startAttackingTarget();
        }
    }
    private void Update()
    {
        if(_target == null)
        {
            FieldOfViewCheck();//(maybe) start shooting
        }
        else
        {
            showDebugAttackLine();
            detectTargetLeftAttackRadius();//check if should stop shooting
        }
    }

    //BULLET ATTACKING:
    private void startAttackingTarget()
    {
        InvokeRepeating("createAndFireBullet", _towerData.towerAttackDelay, _attackFrequency);
    }
    private void createAndFireBullet()
    {
        //x get bullet obj from factory
        //x assign bullet damage value to it
        //bullet look at target
        //instantiate bullet

        GameObject bullet = new GameObject();
        switch (_attackType)
        {
            case AttackType.Regular:
                bullet = _attackFactory.CreateRegularAttack();
                break;
            case AttackType.AreaOf:
                bullet = _attackFactory.CreateAreaOfAttack();
                break;
            case AttackType.Debuff:
                bullet = _attackFactory.CreateDebuffAttack();
                break;
        }
        bullet.GetComponent<Bullet>().SetDamageValue(_bulletDamageValue);
        //TO DO: FIX empty obj created with the bullet obj
        Instantiate(bullet, this.transform.position, this.transform.rotation);
        if (debugOn) Debug.Log($"{this.name}: Shooting bullet! Pew");
    }
    private void stopAttackingTarget()
    {
        CancelInvoke("createAndFireBullet");
    }
    private void detectTargetLeftAttackRadius()
    {
        if(_target != null)
        {
            //TO DO: FIX, detecking the target as out of radius all the time
            if(Vector3.Distance(this.transform.position, _target.transform.position)
                > _attackRadius)
            {
                if (debugOn) Debug.Log($"{this.name}: Target out of reach!");
                _target = null;
                stopAttackingTarget();
            }
        }
    }

    //OTHER:
    private void showDebugAttackLine()
    {
        if (_towerData.showDebugAttackLine)
        {
            if(_target != null)
            {
                Debug.DrawLine(this.transform.position, _target.transform.position, _towerData.debugColor);
            }
        }
    }
}
