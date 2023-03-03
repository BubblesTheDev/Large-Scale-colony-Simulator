using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrain List", menuName = "World Assets/Lists/New Terrain List")]
public class terrainListScriptableObj : ScriptableObject
{
    public List<terrainScriptableObj> listOfTerrains;
}


