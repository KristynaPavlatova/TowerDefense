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
    [SerializeField] private Transform shootFromPoint;

    public enum AttackType
    {
        Regular = 0,
        AreaOf = 1,
        Debuff = 2
    }
    [SerializeField] private AttackType _attackType = AttackType.Regular;

    private GameObject _target;
    private bool _isCurrentlyAttacking;

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
                _bulletDamageValue = _towerData.bulletDamageRegular;
                break;
            case AttackType.AreaOf:
                _attackRadius = _towerData.attackRadiusAreaOf;
                _attackFrequency = _towerData.attackFrequencyAreaOf;
                _bulletDamageValue = _towerData.bulletDamageAreaOf;
                break;
            case AttackType.Debuff:
                _attackRadius = _towerData.attackRadiusDebuff;
                _attackFrequency = _towerData.attackFrequencyDebuff;
                _bulletDamageValue = _towerData.bulletDamageDebuff;
                break;
        }
        _bulletDamageValue *= _currentTowerLevel;
        if (debugOn) Debug.Log($"{this.name}: Switched attack type.");
    }
    private bool FieldOfViewCheck()
    {
        Collider[] foundColliders = Physics.OverlapSphere(transform.position, _attackRadius, _towerData.enemyLayerMask);
        if(foundColliders.Length != 0)
        {
            _target = foundColliders[0].gameObject;
            if (debugOn) Debug.Log($"{this.name}: Found new target.");
            return true;
        }
        else
        {
            return false;
        }
    }
    private void FixedUpdate()
    {
        if(_target == null)
        {
            if (FieldOfViewCheck() && !_isCurrentlyAttacking)//(maybe) start shooting
            {
                startAttackingTarget();
                _isCurrentlyAttacking = true;
            }
        }
        else
        {
            showDebugAttackLine();
            if (detectTargetLeftAttackRadius())//check if should stop shooting
            {
                _isCurrentlyAttacking = false;
            }
        }
    }

    //BULLET ATTACKING:
    private void startAttackingTarget()
    {
        InvokeRepeating("createAndFireBullet", _towerData.towerAttackDelay, _attackFrequency);
    }
    private void createAndFireBullet()
    {
        switch (_attackType)
        {
            case AttackType.Regular:
                GameObject bulletRegular = Instantiate(_attackFactory.CreateRegularAttack(), shootFromPoint.position, this.transform.rotation);
                bulletRegular.GetComponent<BulletRegular>().targetPosition = _target.transform.position;
                break;
            case AttackType.AreaOf:
                GameObject bulletAreaOf = Instantiate(_attackFactory.CreateAreaOfAttack(), shootFromPoint.position, this.transform.rotation);
                bulletAreaOf.GetComponent<BulletAreaOf>().targetPosition = _target.transform.position;
                break;
            case AttackType.Debuff:
                GameObject bulletDebuff = Instantiate(_attackFactory.CreateDebuffAttack(), shootFromPoint.position, this.transform.rotation);
                bulletDebuff.GetComponent<BulletDebuff>().targetPosition = _target.transform.position;
                break;
        }
        if (debugOn) Debug.Log($"{this.name}: Shooting bullet! Pew");
    }
    private void stopAttackingTarget()
    {
        CancelInvoke("createAndFireBullet");
    }
    private bool detectTargetLeftAttackRadius()
    {
        if (_target != null)
        {
            if (distanceToTarget() >= _attackRadius + _towerData.attackRadiusToleranceValue)
            {
                if (debugOn) Debug.Log($"{this.name}: Target out of reach!");
                _target = null;
                stopAttackingTarget();
                return true;
            }
            else return false;
        }
        else return false;
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
    private Vector3 directionToTarget()
    {
        if (_target != null)
        {
            Vector3 dir = _target.transform.position - this.transform.position;
            return dir.normalized;
        }
        else return Vector3.zero;
    }
    private float distanceToTarget()
    {
        if (_target != null)
        {
            return Vector3.Distance(this.transform.position, _target.transform.position);
        }
        else return 0;
    }
}
