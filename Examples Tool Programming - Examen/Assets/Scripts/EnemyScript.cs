using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyPath path;
    [SerializeField] private int currentIndex;
    [SerializeField] private bool isInReverse;
    [SerializeField] private Transform MeshHolder;
    [SerializeField] private Light Elight;
    private GameObject Player;

    [SerializeField] private EnemyStats stats;

    public float AttackRadius
    {
        get { return stats.attackradius; }
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        agent.SetDestination(path.GetSpotAt(currentIndex));
        UpdateComponent();
    }

    void Update()

    {
        if (Vector3.Distance(transform.position, path.GetSpotAt(currentIndex)) < 2f)
        {
            if (isInReverse)
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    if (path.CanLoop)
                    {
                        currentIndex = path.PathLenth - 1;
                    }
                    else
                    {
                        currentIndex = 1;
                        isInReverse = false;
                    }
                }
            }
            else
            {
                currentIndex++;
                if (currentIndex >= path.PathLenth)
                {
                    if (path.CanLoop)
                    {
                        currentIndex = 0;
                    }
                    else
                    {
                        currentIndex = path.PathLenth - 2;
                        isInReverse = true;
                    }
                }
            }

            agent.SetDestination(path.GetSpotAt(currentIndex));
        }

        if (Player && Vector3.Distance(transform.position, Player.transform.position) < stats.attackradius)
        {
            Destroy(Player);
        }
    }


    public void UpdateComponent()
    {

        GetComponentInChildren<MeshRenderer>().material = stats.MeshColor;
        MeshHolder.localScale = Vector3.one * stats.size;
        agent.speed = stats.speed;
        GetComponentInChildren<Light>().intensity = stats.lightIntensity;
        GetComponentInChildren<Light>().color= stats.lightColor;



    }

    public void SwapStats(EnemyStats newStats)
    {
        stats = newStats;
        UpdateComponent();

    }
}
