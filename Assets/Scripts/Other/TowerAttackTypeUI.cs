using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerAttackTypeUI : MonoBehaviour
{
    public bool debugOn;

    [SerializeField] private GameObject _regularAttackButton;
    [SerializeField] private GameObject _areaOfAttackButton;
    [SerializeField] private GameObject _debuffAttackButton;
    [SerializeField] private Image _selectionImageUI;
    
    private Parcel _parcel;
    [SerializeField] private Tower _tower;//tower on selected parcel

    private void Awake()
    {
        Parcel.OnParcelSelected += displayUI;
        Parcel.OnParcelUnselected += hideUI;
    }
    void Start()
    {
        Debug.Assert(_regularAttackButton, $"{this.name}: Regular attack button reference is missing!");
        Debug.Assert(_areaOfAttackButton, $"{this.name}: AreaOf attack button reference is missing!");
        Debug.Assert(_debuffAttackButton, $"{this.name}: Debuff attack button reference is missing!");
        Debug.Assert(_selectionImageUI, $"{this.name}: SelectionImageUI Image reference is missing!");
        
        showButtons(false, false, false, false);

        updateSelectionImageUI(Tower.AttackType.Regular);
    }

    private void displayUI(GameObject pParcel)
    {
        //parcel -> tower
        _parcel = pParcel.GetComponent<Parcel>();
        if (!_parcel.isParcelEmpty)
        {
            showButtons(true, true, true, true);

            updateCurrentTower();
            Debug.Assert(_tower, $"{this.name}: 'Tower' script from a tower located on the currently selected parcel could not be found! Perhaps the tower obj does not exist on the parcel ");
        }
    }
    private void hideUI()
    {
        showButtons(false, false, false, false);
    }
    private void showButtons(bool pRegular, bool pAreaOf, bool pDestroy, bool pSelectionUI)
    {
        _regularAttackButton.SetActive(pRegular);
        _areaOfAttackButton.SetActive(pAreaOf);
        _debuffAttackButton.SetActive(pDestroy);
        _selectionImageUI.enabled = pSelectionUI;
    }
    private void updateCurrentTower()
    {
        _tower = _parcel.GetTower;
        Debug.Assert(_tower, $"{this.name}: Could not get Tower from currently selected Parcel!");
    }

    //CHANGE TOWER ATTACK TYPE
    public void ChangeAttackToRegular()
    {
        updateCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to Regular.");
        _tower.ChangeTowerAttackType(Tower.AttackType.Regular);
        updateSelectionImageUI(Tower.AttackType.Regular);
    }
    public void ChangeAttackToAreaOf()
    {
        updateCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to AreaOf.");
        _tower.ChangeTowerAttackType(Tower.AttackType.AreaOf);
        updateSelectionImageUI(Tower.AttackType.AreaOf);
    }
    public void ChangeAttackToDebuff()
    {
        updateCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to Debuff.");
        _tower.ChangeTowerAttackType(Tower.AttackType.Debuff);
        updateSelectionImageUI(Tower.AttackType.Debuff);
    }
    private void updateSelectionImageUI(Tower.AttackType pAttackType)
    {
        //check what is the current selected
        switch (pAttackType)
        {
            case Tower.AttackType.Regular:
                _selectionImageUI.transform.position = _regularAttackButton.transform.position;
                break;
            case Tower.AttackType.AreaOf:
                _selectionImageUI.transform.position = _areaOfAttackButton.transform.position;
                break;
            case Tower.AttackType.Debuff:
                _selectionImageUI.transform.position = _debuffAttackButton.transform.position;
                break;
        }
    }
}
