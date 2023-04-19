using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Floor Asset", menuName = "World Assets/Asset/New Floor Asset")]
public class floorScriptableObj : ScriptableObject
{
    [Header("Stats")]
    public Tile floorAsset;
    public float heightValue;

}
