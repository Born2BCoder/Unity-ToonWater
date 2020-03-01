using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perlin_Water : MonoBehaviour
{

    private Perlin Perlin_Noise;

    public float Distorcion;
    public float Velocidad;

    private Vector3[] Base;
    
    void Start()
    {
        Perlin_Noise = new Perlin();
    }

    
    void Update()
    {
        Mesh _mesh = GetComponent<MeshFilter>().mesh;

        if(Base == null)
        {
            Base = new Vector3[_mesh.vertexCount];
            Base = _mesh.vertices;
        }

        Vector3[] Vertices = _mesh.vertices;

        float timeX = Time.time * Velocidad;
        float timeY = Time.time * Velocidad;
        float timeZ = Time.time * Velocidad;

        for(int i = 0; i < Vertices.Length; i++)
        {
            Vector3 Auxiliar = Base[i];

            Auxiliar.x += Perlin_Noise.Noise(timeX + Auxiliar.x, timeX + Auxiliar.y, timeX + Auxiliar.z) * Distorcion;
            Auxiliar.y += Perlin_Noise.Noise(timeY + Auxiliar.x, timeY + Auxiliar.y, timeY + Auxiliar.z) * Distorcion;
            Auxiliar.z += Perlin_Noise.Noise(timeZ + Auxiliar.x, timeZ + Auxiliar.y, timeZ + Auxiliar.z) * Distorcion;

            Vertices[i] = Auxiliar;

        }

        _mesh.vertices = Vertices;
        _mesh.RecalculateNormals();

    }
}
