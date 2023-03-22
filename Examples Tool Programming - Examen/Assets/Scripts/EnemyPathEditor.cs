using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EnemyPath))]      

class EnemyPathEditor  : Editor
{   
    public override void OnInspectorGUI()
    {
        EnemyPath path = (EnemyPath)target;
        Undo.RecordObject(path, "Change Path");
        if (GUILayout.Button("Add Spot"))
        {
            Transform newSpot = Instantiate(path.PrefabSpot, path.transform).transform;
            newSpot.position = path.GetSpotAt(path.PathLenth - 1) + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
            newSpot.gameObject.name = "Spot - " + (path.PathLenth + 1);
            path.AddSPot(newSpot);
        }

        if (GUILayout.Button("Clean"))
        {
            for (int i = 0; i < path.PathLenth; i++)
            {
                if (!path.SpotExistInList(path.transform.GetChild(i)))
                {
                    DestroyImmediate(path.transform.GetChild(i).gameObject);
                    i--;
                }
                
            }

        }

        base.OnInspectorGUI();
    }
       
}
