using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class EnemyPath : MonoBehaviour
{
    [SerializeField] private List<Transform> spots;

    [SerializeField] private bool canLoop;

    public GameObject PrefabSpot;

    public int PathLenth
    {
        get
        {
            return spots.Count;
        }
    }

    public Vector3 GetSpotAt(int index)
    {
        return index < 0 || index >= spots.Count ? Vector3.zero : spots[index].position;
    }

    public bool CanLoop
    {
        get { return canLoop; }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Transform pos in spots)
        {
            Gizmos.DrawSphere(pos.position, 0.3f);
            Handles.Label(pos.position + (Vector3.up * 0.5f), new GUIContent(pos.gameObject.name));
        }
        if (spots.Count > 2) return;
        Handles.color = Color.red;
        for (int i = 0; i < spots.Count - 1; i++)
        {
            Handles.DrawAAPolyLine(spots[i].position, spots[i + 1].position);
        }
        if (canLoop)
        {
            Handles.color = Color.red;
            Handles.DrawAAPolyLine(spots[0].position, spots[spots.Count - 1].position);
        }
    }

#endif

    public void AddSPot(Transform NewS)
    {
        spots.Add(NewS);
    }

    public bool SpotExistInList(Transform Spot)
    {
        return spots.Contains(Spot);
    }
}