using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttackFactory : MonoBehaviour
{
    public abstract GameObject CreateRegularAttack();
    public abstract GameObject CreateAreaOfAttack();
    public abstract GameObject CreateDebuffAttack();
}
