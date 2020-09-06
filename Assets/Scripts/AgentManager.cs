using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    private List<Agent> ActiveAgents;

    void Start()
    {
        ActiveAgents = new List<Agent>();

        Agent newAgent = new Agent();
        SpawnAgent(newAgent);
    }

    public void SpawnAgent(Agent agent)
    {
        ActiveAgents.Add(agent);
    }
}
