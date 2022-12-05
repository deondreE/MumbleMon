using System;
using UnityEngine;

namespace _Scripts.Tools.MapGenerator
{
    public class PerlinNoise : MonoBehaviour
    {
        [SerializeField] private int width = 100;
        [SerializeField] private int height = 100;
        [SerializeField] private float scale = 20f;

        public float CalculateColor(int x, int y)
        {
            float xCoord = (float)x / width * scale;
            float yCoord = (float)y / height * scale;

            float sample = Mathf.PerlinNoise(xCoord, yCoord);
            return Mathf.PerlinNoise(xCoord, yCoord);
        }
    }
}