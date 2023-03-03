using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrain Asset", menuName = "World Assets/Asset/New Terrain Asset")]
public class terrainScriptableObj : ScriptableObject
{
    [Header("Stats")]
    public GameObject terrainAsset;
}
