using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class gridFunctions
{


    public static Vector2 getWorldPosOfCell(Vector2Int cellId, Vector2 gridStartPos)
    {
        Vector2 returnPos;

        returnPos = gridStartPos + new Vector2(cellId.x, cellId.y);
        return returnPos;
    }

    public static float[,] generateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0) scale = 0.0001f;

        float minNoiseHeight = float.MaxValue;
        float maxNoiseHeight = float.MinValue;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float tempY = y / scale * frequency + octaveOffsets[i].x;
                    float tempX = x / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(tempX, tempY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (maxNoiseHeight < noiseHeight) maxNoiseHeight = noiseHeight;
                if (minNoiseHeight > noiseHeight) minNoiseHeight = noiseHeight;

                noiseMap[x, y] = noiseHeight;
            }
        }

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
    
}
