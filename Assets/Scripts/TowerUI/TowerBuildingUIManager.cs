using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuildingUIManager : MonoBehaviour
{
    public bool debugOn;

    [SerializeField] private GameObject _buildTowerButton;
    [SerializeField] private GameObject _upgradeTowerButton;
    [SerializeField] private GameObject _destroyTowerButton;

    [SerializeField] private Parcel _parcel;

    private void Awake()
    {
        Parcel.OnParcelSelected += displayUI;
        Parcel.OnParcelUnselected += hideUI;
    }
    void Start()
    {
        showButtons(false, false, false);
    }
    private void showButtons(bool pBuild, bool pUpgrade, bool pDestroy)
    {
        if (debugOn) Debug.Log($"{this.name}: ShowButtons build {pBuild}, upgrade {pUpgrade}, destroy {pDestroy}");
        _buildTowerButton.SetActive(pBuild);
        _upgradeTowerButton.SetActive(pUpgrade);
        _destroyTowerButton.SetActive(pDestroy);
    }
    private void displayUI(GameObject pParcel)
    {
        if (debugOn) Debug.Log($"{this.name}: DisplayUI for parcel {pParcel.name}");
        if(_parcel != null)
            _parcel = null;
        _parcel = pParcel.GetComponent<Parcel>();

        switch (_parcel.isParcelEmpty)
        {
            case true:
                //Display UI for only building the tower
                showButtons(true, false, false);
                break;
            case false:
                //Display UI for both upgrading & destroying the existing tower
                showButtons(false, true, true);
                break;
        }
    }
    private void hideUI()
    {
        showButtons(false, false, false);
        if (_parcel != null) _parcel = null;
    }

    //BUTTON METHODS
    public void BuildTower() => _parcel.BuildTower();
    public void UpgradeTower() => _parcel.UpgradeTower();
    public void DestroyTower() => _parcel.DestroyTower();
}
