using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles active agents, spawning and despawning of agents
public class AgentManager : MonoBehaviour
{
    private List<Agent> ActiveAgents;

    void Start()
    {
        // Load Agent assets
        AgentLibrary.LoadAgentLibrary();
        // initialise AgentUtility
        AgentUtility.InitialiseAgentUtility(this);

        ActiveAgents = new List<Agent>();

        SpawnAgent(AgentLibrary.Grub);     
    }

    public void SpawnAgent(AgentType agent)
    {
        var newAgentGO = Instantiate<GameObject>(agent.agentGameObject, Vector3.zero, Quaternion.identity, this.transform);
        Agent newAgent = newAgentGO.GetComponent<Agent>();
        ActiveAgents.Add(newAgent);
    }

    public void DespawnAgent(Agent agent)
    {
        ActiveAgents.Remove(agent);
        Destroy(agent);
    }
}
