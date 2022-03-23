using UnityEngine;



public class TowerActionEventManager : MonoBehaviour
{
    /* This class is a middle step between the TowerBuildingManager,
     * telling the parcel to do an action with its tower, and the PlayerResourcesManager,
     * raking care of permitting spending player money and increasing it.
     */
    
    //Updating
    public delegate bool TowerUpgrading(int pTowerLevel);//Callback signature
    public static event TowerUpgrading OnTowerUpgrading;//Event declaration
    //Building
    public delegate bool TowerBuilding();//Callback signature
    public static event TowerBuilding OnTowerBuilding;//Event declaration
    //Destroying
    public delegate void TowerDestroying(int pTowerLevel);//Callback signature
    public static event TowerDestroying OnTowerDestroying;//Event declaration
    

    public bool sendTowerUpgrading(int pTowerLevel)
    {
        return OnTowerUpgrading(pTowerLevel);
    }
    public bool sendTowerBuilding()
    {
        return OnTowerBuilding();
    }
    //Tower can get destroyed any time regardless of the current player money value
    public void sendTowerDestroying(int pTowerLevel)
    {
        OnTowerDestroying(pTowerLevel);
    }
    
}
