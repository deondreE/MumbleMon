using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace _Scripts.Tools.MapGenerator
{
    public class MeshGenerator : MonoBehaviour
    {
        private Mesh _mesh;

        private Vector3[] _vertices;
        private int[] _triangles;
        private Color[] _colors;

        private float _minTerrainHeight;
        private float _maxTerrainHeight;

        [SerializeField] private int xSize = 20;
        [SerializeField] private int zSize = 20;
        [SerializeField] private PerlinNoise perlinNoise;

        [SerializeField] private Gradient gradient;

        private void Start()
        {
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;

            CreateShape();
            UpdateMesh();
        }

        private void CreateShape()
        {
            _vertices = new Vector3[(xSize + 1) * (zSize + 1)];
            
            // Generate the vertices for the points on a grid.
            // Loop over all vertices;
            for (int i = 0, z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    float y = perlinNoise.CalculateColor(z, x);
                    _vertices[i] = new Vector3(x, y, z);

                    if (y > _maxTerrainHeight)
                        _maxTerrainHeight = y;

                    if (y < _minTerrainHeight)
                        _minTerrainHeight = y;
                    
                    i++;
                }
            }

            _triangles = new int[xSize * zSize * 6];
            int vert = 0;
            int tris = 0;
            // Generate the Triangle mesh
            for (int z = 0; z < zSize; z++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    _triangles[tris + 0] = vert + 0;
                    _triangles[tris + 1] = vert + xSize + 1;
                    _triangles[tris + 2] = vert + 1;
                    _triangles[tris + 3] = vert + 1;
                    _triangles[tris + 4] = vert + xSize + 1;
                    _triangles[tris + 5] = vert + xSize + 2;
                    
                    vert++;
                    tris += 6;
                }
                vert++;
            }

            // change the color based on vertex : https://docs.unity3d.com/ScriptReference/Mesh-colors.html
            _colors = new Color[(xSize + 1) * (zSize + 1)];
            for (int i = 0, z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    // find a height between 0 -> 1
                    float height = Mathf.InverseLerp(_minTerrainHeight, _maxTerrainHeight, _vertices[i].y);
                    _colors[i] = gradient.Evaluate(height);
                    i++;
                }
            }
        }

        private void UpdateMesh()
        {
            _mesh.Clear();

            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _mesh.colors = _colors;
            
            _mesh.RecalculateNormals();
        }

        // This code is used in the case of debugging
        /*private void OnDrawGizmos()
        {
            if (_vertices == null)
                return;
            
            for (int i = 0; i < _vertices.Length; i++)
            {
                Gizmos.DrawSphere(_vertices[i], 0.1f);
            }
        }*/ 
    }
}