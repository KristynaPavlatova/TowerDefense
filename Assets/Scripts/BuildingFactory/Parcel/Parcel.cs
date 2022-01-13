using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Parcel : MonoBehaviour, ISelectable
{
    public bool debugOn;
    [Space(10)]
    public Transform towerSpawnPoint;
    [Header("Mouse selection:")]
    [Space(10)]
    public Color selectedColor;
    private Color _originalColor;
    private Renderer _rend;
    
    private AbstractBuildingFactory _buildingFactory;
    private GameObject _tower;

    //SELECTING PARCEL
    public void SelectionEnter()
    {
        _rend.materials[1].color = selectedColor;
        //display UI options for what to do with this parcel
    }
    public void SelectionExit()
    {
       _rend.materials[1].color = _originalColor;
    }

    //BUILD ON PARCEL
    public void BuildTower()
    {
        if (_tower is null)
        {
            if (debugOn) Debug.Log($"{this.name}: Building a new tower!");
            _buildingFactory = new TowerFactory();;
            _tower = _buildingFactory.CreateBuilding(1);//Get basic level tower
            if (_tower != null)
            {
                Instantiate(_tower, towerSpawnPoint.position, Quaternion.identity, this.transform);
                if (debugOn) Debug.Log($"{this.name}: New tower was build!");
            }
        }
        else if (debugOn) Debug.Log($"{this.name}: New tower cannot be build! Parcel already occupied.");
    }
    public void UpgradeTower()
    {
        if(_tower != null)
        {
            if (debugOn) Debug.Log($"{this.name}: Upgrading tower!");

            int lastTowerLevel = _tower.GetComponent<Tower>().GetTowerLevel;
            
            //Try to upgrade the current tower
            var temporaryTower = _buildingFactory.CreateBuilding(lastTowerLevel + 1);
            if(temporaryTower != null)
            {
                _tower = temporaryTower;
                Destroy(this.transform.GetChild(1).gameObject);
                Instantiate(_tower, towerSpawnPoint.position, Quaternion.identity, this.transform);
                if (debugOn) Debug.Log($"{this.name}: Tower upgraded!");
            }
            else
            if (debugOn) Debug.Log($"{this.name}: Tower cannot be upgraded! Maximum level reached.");
        }
        else if (debugOn) Debug.Log($"{this.name}: Parcel has no tower that can be upgraded!");
    }
    public void DestroyTower()
    {
        if(_tower != null)
        {
            Destroy(this.transform.GetChild(1).gameObject);
            _tower = null;
            if (debugOn) Debug.Log($"{this.name}: Tower destroyed!");
        }else if (debugOn) Debug.Log($"{this.name}: No tower to be destroyed!");
    }
    
    //OTHER
    void Start()
    {
        _rend = this.GetComponent<Renderer>();
        _originalColor = _rend.materials[1].color;
    }
    void Update()
    {
    }
}