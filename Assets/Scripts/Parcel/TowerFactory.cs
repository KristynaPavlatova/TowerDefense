using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : AbstractBuildingFactory
{
    public bool debugOn;

    //Parcel asks this fatory for a tower
    public override GameObject CreateBuilding()
    {
        if (debugOn) Debug.Log("creating tower in factory");
        var towerObj = Resources.Load<GameObject>("Towers/Tower1");
        if (debugOn) Debug.Log("returning tower from factory");
        return towerObj;
    }

    public override void UpdateBuilding()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
