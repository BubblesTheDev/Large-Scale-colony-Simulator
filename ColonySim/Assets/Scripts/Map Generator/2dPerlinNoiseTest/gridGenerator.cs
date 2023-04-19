using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class gridGenerator : MonoBehaviour
{
    //[Header("Debug Settings")]

    [Header("Generator Settings")]
    public int gridWidth;
    public int gridHeight;
    public float heightOffset;
    public cellData[,] cells;
    public Tilemap TilesMap;
    public floorListScriptableObj floorList;

    [Header("Noise Settings")]
    public int seed;
    [Range(50, 500)]
    public float perlinScale;

    public int octaves;
    [Range(.01f,1f)]
    public float persistance;
    [Range (2f,3.8f)]
    public float lacunarity;
    public Vector2 offset;

    private void Awake()
    {
        seed = Random.Range(1, 100000);
    }

    public void generateGrid()
    {
        float[,] noisemap = gridFunctions.generateNoiseMap(gridWidth, gridHeight, seed, perlinScale, octaves, persistance, lacunarity, offset);

        cells = new cellData[gridWidth,gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float currentHeight = noisemap[x, y];
                for (int i = 0; i < floorList.listOfFloors.Count; i++)
                {
                    if (Mathf.Clamp(currentHeight + heightOffset,0.1f,1f) <= floorList.listOfFloors[i].heightValue)
                    {
                        Vector2Int tempId = new Vector2Int(x, y);
                        cells[x, y] = new cellData(tempId, floorList.listOfFloors[i].floorAsset);
                        TilesMap.SetTile(new Vector3Int(tempId.x,tempId.y,0), cells[x, y].floorTile);
                        break;
                    }
                }
            }
        }

    }
}

[CustomEditor(typeof(gridGenerator))]
public class gridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        gridGenerator gen = (gridGenerator)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate Map"))
        {
            gen.generateGrid();
        }
        if (GUILayout.Button("Randomize Map"))
        {
            gen.seed = Random.Range(1, 100000);
            //gen.perlinScale = Random.Range(50f, 500f);
            gen.generateGrid();

        }

    }
}

public struct cellData{
    public Vector2Int cellId;
    public Tile floorTile;

    public cellData(Vector2Int cellIdToGive, Tile floorToGive)
    {
        cellId = cellIdToGive;
        floorTile = floorToGive;
    }


}