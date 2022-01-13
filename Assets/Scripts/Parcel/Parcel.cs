using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parcel : MonoBehaviour, ISelectable
{
    public bool debugOn;
    [Space(10)]
    public Transform towerSpawnPoint;

    private AbstractBuildingFactory _buildingFactory;
    private GameObject _tower;

    //SELECTING PARCEL
    public void HoverOver()
    {
        //change color
    }
    public void Selected()
    {
        //change color
        //display UI options for what to do with this parcel
    }

    //BUILDING ON PARCEL
    public void BuildTower()
    {
        if (_tower is null)
        {
            if (debugOn) Debug.Log($"{this.name}: Building a new tower!");
            _buildingFactory = new TowerFactory();
            if (debugOn) Debug.Log($"{this.name}: create building");
            _tower = _buildingFactory.CreateBuilding(1);//Get basic level tower
            if (debugOn) Debug.Log($"{this.name}: got a tower");
            if (_tower != null)
            {
                if (debugOn) Debug.Log($"{this.name}: instantiating tower");
                Instantiate(_tower, towerSpawnPoint.position, Quaternion.identity, this.transform);
                if (debugOn) Debug.Log($"{this.name}: New tower was build!");
            }else if (debugOn) Debug.Log($"{this.name}: Error: New tower could not be build!");

        }
    }
    public void UpgradeTower()
    {
        if(_tower != null)
        {
            if (debugOn) Debug.Log($"{this.name}: Upgrading tower!");

            Destroy(this.transform.GetChild(1).gameObject);
            _tower = _buildingFactory.CreateBuilding(2);//!!!!!
            Instantiate(_tower, towerSpawnPoint.position, Quaternion.identity, this.transform);
            
            if (debugOn) Debug.Log($"{this.name}: Tower upgraded!");
        }
    }
    //DESTORYING ASSETS IS NOT PERMITED!
    //solution: tower factory gives just lvl 1 tower prefab stored in itself
    //each time you want to upgrade the existing tower, tell the tower to upgrade itself
    //The tower then checks its lvl and based on scriptable object it changes its properties
    public void DestroyTower()
    {
        if (_tower != null)
        {
            if (debugOn) Debug.Log($"{this.name}: Tower destroyed!");
            Destroy(_tower);
            _tower = null;
        }
    }
    
    void Start()
    {
    }
    void Update()
    {
        
    }
}
