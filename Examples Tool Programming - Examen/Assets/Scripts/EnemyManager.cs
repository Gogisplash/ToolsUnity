using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyManager : EditorWindow
{
    static public EnemyStats desiredStats;
    [MenuItem("Window/Enemy Manager Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EnemyManager>("Enemy Manager");
    }
    private void OnGUI()
    {
        #region StylesCreation
        GUIStyle TitleStyle = new GUIStyle();
        TitleStyle.fontSize = 28;
        TitleStyle.normal.textColor = Color.red;
        #endregion

        EditorGUI.LabelField(new Rect(3, 1, position.width, 22), "MODIFICATION STATS", TitleStyle);
        EditorGUI.LabelField(new Rect(3, 25, position.width, 20), "SELECTION ENEMIS", EditorStyles.boldLabel);

        desiredStats = EditorGUI.ObjectField(new Rect(3, 50, position.width, 20), "stats désirés", desiredStats, typeof(EnemyStats), false) as EnemyStats;
        if (desiredStats == null)
        {
            EditorGUI.LabelField(new Rect(3, 75, position.width, 20), "Aucun enemi séléctionné", EditorStyles.boldLabel);
        }
        else
        {
            if (!CheckForEnemiesInSelection())
            {
                EditorGUI.LabelField(new Rect(3, 75, position.width, 30), "Aucun Enemie selectionner");
            }
            else
            {
                Rect buttonRect = new Rect(3, 75, position.width, 30);
                if (GUI.Button(buttonRect, "Changer stats pour ->" + desiredStats.name + "<-"))
                {
                    ChangeOfSelectedEnemies();
                }
            }
        }
    }

    private bool CheckForEnemiesInSelection()
    {

        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.GetComponent<EnemyScript>())
            {
                return true;
            }
        }
        return false;
    }
    private void ChangeOfSelectedEnemies()
    {
        if (!CheckForEnemiesInSelection())
        {
            return;
        }
        foreach (GameObject obj in Selection.gameObjects)
        {
            EnemyScript es = obj.GetComponent<EnemyScript>();
            if (es)
            {
                es.SwapStats(desiredStats);
            }
        }

    }
}