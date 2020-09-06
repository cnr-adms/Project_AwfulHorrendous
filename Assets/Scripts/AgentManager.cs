using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    private List<Agent> ActiveAgents;

    void Start()
    {
        AgentLibrary.LoadAgentLibrary();

        ActiveAgents = new List<Agent>();

        SpawnAgent(AgentLibrary.Grub);
       
    }

    public void SpawnAgent(AgentType agent)
    {
        var newAgentGO = Instantiate<GameObject>(agent.agentGameObject, Vector3.zero, Quaternion.identity, this.transform);
        Agent newAgent = newAgentGO.GetComponent<Agent>();
        ActiveAgents.Add(newAgent);
    }
}
