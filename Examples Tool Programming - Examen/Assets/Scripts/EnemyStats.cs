using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(fileName = "New EnemyStats", menuName = "ScriptableObject/EnemyStats")]
public class EnemyStats : ScriptableObject
{

    public Material MeshColor;
    public float attackradius;
    public float speed;
    public float size;
    public float lightIntensity;
    public Color lightColor;

}
