using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    //TO DO: have a sciptable obj reference for different costs
    //-> tower levels upgrades costs, building cost, destroy tower levels different cost

    void Awake()
    {
        TowerActionEventManager.OnTowerUpgrading += upgradeTower;
        TowerActionEventManager.OnTowerBuilding += buildTower;
        TowerActionEventManager.OnTowerDestroying += destroyTower;
    }

    private bool upgradeTower()
    {
        //player money resource has enough to affort the upgrade
        //CHECK: does upgrading different tower levels need to cost different amounts?
        //If so, then have the tower level as a parameter
        return true;
    }
    private bool buildTower()
    {
        //player money resource has enough to affort the upgrade
        return true;
    }
    private void destroyTower()
    {
        //depending on the tower level increase the player money by a value
    }
}
