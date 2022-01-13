using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : AbstractBuildingFactory
{
    public bool debugOn;

    //Parcel asks this fatory for a tower
    public override GameObject CreateBuilding(int pWantedLevel)
    {
        if (debugOn) Debug.Log($"{this.name}: Creating tower in factory");
        var towerObj = Resources.Load<GameObject>("Towers/Tower" + pWantedLevel.ToString());
        
        if (towerObj != null)
        {
            if (debugOn) Debug.Log($"{this.name}: Returning lvl {pWantedLevel} tower from factory");
            
            towerObj.GetComponent<Tower>().SetTowerLevel(pWantedLevel);
            return towerObj;
        }
        else return null;
    }
}
