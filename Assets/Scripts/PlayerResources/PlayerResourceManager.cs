using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerGold))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerResourceManager : MonoBehaviour
{
    //TO DO: have a sciptable obj reference for different costs
    //-> tower levels upgrades costs, building cost, destroy tower levels different cost
    private PlayerGold _playerGold;
    private PlayerHealth _playerHealth;

    [SerializeField] private TowerData _towerData;
    [SerializeField] private Text _goldAmountChangeValueText;
    [SerializeField] private int _secondsToDisplayValueChange;

    void Awake()
    {
        TowerActionEventManager.OnTowerUpgrading += upgradeTower;
        TowerActionEventManager.OnTowerBuilding += buildTower;
        TowerActionEventManager.OnTowerDestroying += destroyTower;

        checkReferences();
    }
    private void checkReferences()
    {
        _playerGold = this.GetComponent<PlayerGold>();
        Debug.Assert(_playerGold, $"{this.name}: player gold reference is not set!");
        _playerHealth = this.GetComponent<PlayerHealth>();
        Debug.Assert(_playerHealth, $"{this.name}: player health reference is not set!");

        Debug.Assert(_towerData, $"{this.name}: towerData reference of the scriptable object is not set!");
    }

    private bool upgradeTower(int pTowerLevel)
    {
        //player money resource has enough to affort the upgrade
        //CHECK: does upgrading different tower levels need to cost different amounts?
        //If so, then have the tower level as a parameter

        //ASK "PLAYER GOLD" if player can afford upgrading a tower
        if (_playerGold.DecreasePlayerGold(pTowerLevel * _towerData.towerUpgradeCostIncrease))
        {
            //TRIGGER UI!
            return true;
        }
        else
        {
            //TRIGGER UI!
            return false;
        }
    }
    private bool buildTower()
    {
        if (_playerGold.DecreasePlayerGold(_towerData.towerBasePrice))
        {
            //TRIGGER UI!
            return true;
        }
        else
        {
            //TRIGGER UI!
            return false;
        }
    }
    private void destroyTower(int pTowerLevel)
    {
        //depending on the tower level increase the player money by a value
    }
    private void displayChangeInValue(int pValue, bool pIsIncreasing)
    {
        string _text;
        if (pIsIncreasing)
        {
            _text = "+";
        }
        else
        {
            _text = "-";
        }
        _goldAmountChangeValueText.text = _text.ToString() + pValue.ToString();
        _goldAmountChangeValueText.enabled = true;
        //start Timer
    }
    //Timer UI
    //
    //function Update()
    //{
    //    timeLeft -= Time.deltaTime;
    //    if (timeLeft < 0)
    //    {
    //        GameOver();
    //    }
    //}
    // Bool for starting this timer
    //inside this timer setting the UI value text off
    //_goldAmountChangeValueText.enabled = false;


}
