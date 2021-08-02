using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : Health
{
    AIAgent agent;
    protected override void OnStart()
    {
        agent = GetComponent<AIAgent>();
    }

    protected override void OnDeath(Vector3 direction)
    {
        AIState_Death deathState = agent.stateMachine.GetState(AIStateID.Death) as AIState_Death;
        deathState.direction = direction;
        agent.stateMachine.ChangeState(AIStateID.Death);
    }

    protected override void OnDamage(Vector3 direction)
    {

    }
}
