using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBuildingFactory : MonoBehaviour
{
    public abstract GameObject CreateBuilding();
    public abstract void UpdateBuilding();
}
