using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public static class ExtraMapFunctions {

    public static Vector3 getWorldPosOfCell(Vector3 cellId, Vector3 chunkStartPosition, float cellSize) {
        Vector3 worldPosToReturn;

        Vector3 temp = new Vector3(cellId.x,cellId.y,cellId.z) * cellSize;
        worldPosToReturn = chunkStartPosition + temp ;

        return worldPosToReturn;
    }

    public static bool[,,] generateChunkNoiseMap(int chunkWidth, int chunkHeight, int chunkDepth, float detectionValue, float noiseScale, Vector3 offset) {

        bool[,,] chunkNoiseMap = new bool[chunkWidth, chunkHeight, chunkDepth];



        for (int x = 0; x < chunkWidth; x++) {
            for (int y = 0; y < chunkHeight; y++) {
                for (int z = 0; z < chunkDepth; z++) {
                    if (perlinNoisePoint3D(x * noiseScale + offset.x, y * noiseScale + offset.y, z * noiseScale + offset.z) > detectionValue) {
                        chunkNoiseMap[x,y,z] = true;
                    } else chunkNoiseMap[x,y,z] = false;
                }
            }
        }

        return chunkNoiseMap;

    }


    public static float perlinNoisePoint3D(float x, float y, float z) {

        float ab = Mathf.PerlinNoise(x, y);
        float bc = Mathf.PerlinNoise(y, z);
        float ac = Mathf.PerlinNoise(x, z);

        float ba = Mathf.PerlinNoise(y, x);
        float cb = Mathf.PerlinNoise(z, y);
        float ca = Mathf.PerlinNoise(z, x);

        float abc = ab + bc + ac + ba + cb + ca;

        return abc / 6f;

    }

    

}
