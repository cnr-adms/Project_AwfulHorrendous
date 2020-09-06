using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper methods for agents
public static class AgentUtility 
{
    public static AgentManager AgentManager { get; private set; }

    public static void InitialiseAgentUtility(AgentManager agentManager)
    {
        AgentManager = agentManager;
    }
}
