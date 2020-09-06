using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AgentLibrary
{
    public static AgentType Grub;

    public static void LoadAgentLibrary()
    {
        Grub = new AgentType(Resources.Load
            ("Grub", typeof(GameObject)) as GameObject);
    }
}

public class AgentType
{
    public GameObject agentGameObject;
    public Agent agent;

    public AgentType(GameObject agentGameObject)
    {
        if (agentGameObject)
        {
            this.agentGameObject = agentGameObject;
            agent = agentGameObject.GetComponent<Agent>();
        }
        else
            Debug.LogWarning("Agent Library: Agent Prefab not found.");
    }
}
