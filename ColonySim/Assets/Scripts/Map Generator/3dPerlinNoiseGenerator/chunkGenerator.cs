using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class chunkGenerator : MonoBehaviour
{
    [Header("Chunk Settings")]
    public int chunkWidthSize = 100;
    public int chunkHeightSize = 100;
    public int chunkDepthSize = 100;
    public float cellSize = 1;
    [Range(0.0f, 1.0f)]
    public float cellPercentageValue = 0.25f;


    [Space, Header("Spawning Settings")]
    [Range(0, 999999)]
    public int seed = 999999/2;
    public float noiseScale;
    public Vector3 chunkStartPos;
    public List<chunk> chunks;
    public int chunkCount;
    private int ringIndex = 1;

    private void Awake() {
        generateNewChunk(chunkStartPos + Vector3.forward * (chunkDepthSize * chunkCount));
    }

    private void Update() {

    }

    public void generateNewChunk(Vector3 chunkPosToGive) {
        chunks.Add(new chunk(ExtraMapFunctions.generateChunkNoiseMap(chunkWidthSize, chunkHeightSize, chunkDepthSize, cellPercentageValue, noiseScale, chunkPosToGive ), chunkPosToGive));
        chunkCount++;
    }


    private void OnDrawGizmosSelected() {

     Gizmos.color = Color.black;

        for (int i = 0; i < chunkCount; i++) {
            for (int x = 0; x < chunkWidthSize; x++) {
                for (int y = 0; y < chunkHeightSize; y++) {
                    for (int z = 0; z < chunkDepthSize; z++) {
                        if (chunks[i].noiseMapPoints[x, y, z] == true) {
                            Gizmos.DrawWireSphere(chunkStartPos + ExtraMapFunctions.getWorldPosOfCell(new Vector3(x, y, z), chunks[i].chunkIndex, cellSize), cellSize/2f);
                        }
                    }
                }
            }
        }
    }
}

[System.Serializable]
public struct chunk{
    public bool[,,] noiseMapPoints;
    public Vector3 chunkIndex;
    

    public chunk(bool[,,] noiseMapPointsTG, Vector3 chunkIndexTG) {
        noiseMapPoints = noiseMapPointsTG;
        chunkIndex = chunkIndexTG;
    }
}
