using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackTypeUI : MonoBehaviour
{
    public bool debugOn;

    [SerializeField] private GameObject _regularAttackButton;
    [SerializeField] private GameObject _areaOfAttackButton;
    [SerializeField] private GameObject _debuffAttackButton;

    private Parcel _parcel;
    [SerializeField] private Tower _tower;//tower on selected parcel

    private void Awake()
    {
        Parcel.OnParcelSelected += displayUI;
        Parcel.OnParcelUnselected += hideUI;
    }
    void Start()
    {
        showButtons(false, false, false);
    }

    private void displayUI(GameObject pParcel)
    {
        //parcel -> tower
        _parcel = pParcel.GetComponent<Parcel>();
        if (!_parcel.isParcelEmpty)
        {
            showButtons(true, true, true);

            getCurrentTower();
            Debug.Assert(_tower, $"{this.name}: 'Tower' script from a tower located on the currently selected parcel could not be found! Perhaps the tower obj does not exist on the parcel ");
        }
    }
    private void hideUI()
    {
        showButtons(false, false, false);
    }
    private void showButtons(bool pRegular, bool pAreaOf, bool pDestroy)
    {
        //if (debugOn) Debug.Log($"{this.name}: ShowButtons build {pRegular}, upgrade {pAreaOf}, destroy {pDestroy}");
        _regularAttackButton.SetActive(pRegular);
        _areaOfAttackButton.SetActive(pAreaOf);
        _debuffAttackButton.SetActive(pDestroy);
    }
    private void getCurrentTower()
    {
        _tower = _parcel.GetTower;
    }

    //CHANGE TOWER ATTACK TYPE
    public void ChangeAttackToRegular()
    {
        getCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to Regular.");
        _tower.ChangeTowerAttackType(Tower.AttackType.Regular);
    }
    public void ChangeAttackToAreaOf()
    {
        getCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to AreaOf.");
        _tower.ChangeTowerAttackType(Tower.AttackType.AreaOf);
    }
    public void ChangeAttackToDebuff()
    {
        getCurrentTower();
        if (debugOn) Debug.Log($"{this.name}: Changing {_tower.name} attack type {_tower.getAttackType.ToString()} to Debuff.");
        _tower.ChangeTowerAttackType(Tower.AttackType.Debuff);
    }
}
