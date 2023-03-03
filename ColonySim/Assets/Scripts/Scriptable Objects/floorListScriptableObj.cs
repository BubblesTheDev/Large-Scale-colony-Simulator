using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Floor List", menuName = "World Assets/Lists/New Floor List")]
public class floorListScriptableObj : ScriptableObject
{
    public List<floorScriptableObj> listOfFloors;
}
