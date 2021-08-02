using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_AttackPlayer : AIState
{
    public AIStateID GetID()
    {
        return AIStateID.AttackPlayer;
    }

    public void Enter(AIAgent agent)
    {
        agent.weapons.ActivateWeapon();
        agent.weapons.SetTarget(agent.playerTransform);
        agent.navMeshAgent.stoppingDistance = 5.0f;
        agent.weapons.SetFiring(true);
    }

    public void Exit(AIAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 0.0f;
    }

    public void Update(AIAgent agent)
    {
        agent.navMeshAgent.destination = agent.playerTransform.position;
    }
}
