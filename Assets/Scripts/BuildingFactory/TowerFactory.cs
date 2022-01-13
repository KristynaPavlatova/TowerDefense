using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : AbstractBuildingFactory
{
    public bool debugOn;

    public override GameObject CreateBuilding(int pWantedLevel)
    {
        if (debugOn) Debug.Log($"{this.name}: Creating tower in factory");
        
        var towerObj = Resources.Load<GameObject>("Towers/Tower" + pWantedLevel.ToString());
        if (towerObj != null)//There are more levels of that building
        {
            if (debugOn) Debug.Log($"{this.name}: Returning lvl {pWantedLevel} tower from factory");
            
            towerObj.GetComponent<Tower>().SetTowerLevel(pWantedLevel);
            return towerObj;
        }
        else return null;//No more levels of that building, don't return any
    }
}
