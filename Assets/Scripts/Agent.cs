using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public List<Prop> AgentInventory;

    void Awake()
    {
        AgentInventory = new List<Prop>();
    }

    public void MoveTo(Vector3 position)
    {
        // trigger new move request
    }
}
