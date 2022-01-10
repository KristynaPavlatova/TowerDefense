using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parcel : MonoBehaviour, ISelectable
{
    public Transform towerSpawnPoint;

    private AbstractBuildingFactory _buildingFactory;

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
        _buildingFactory = new TowerFactory();
        var tower = _buildingFactory.CreateBuilding();
        Instantiate(tower, towerSpawnPoint.position, Quaternion.identity);
    }
    
    void Start()
    {
    }
    void Update()
    {
        
    }
}
