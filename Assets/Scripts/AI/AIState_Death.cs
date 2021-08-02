using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState_Death : AIState
{
    public Vector3 direction;

    AIStateID AIState.GetID()
    {
        return AIStateID.Death;
    }

    void AIState.Enter(AIAgent agent)
    {
        agent.weapons.DropWeapon();
        agent.ragdoll.ActivateRagdoll();
        direction.y = 1;
        agent.ragdoll.ApplyForce(direction * agent.config.dieForce);
        agent.ui.gameObject.SetActive(false);
        agent.mesh.updateWhenOffscreen = true;
        
    }

    void AIState.Exit(AIAgent agent)
    {
        
    }

    void AIState.Update(AIAgent agent)
    {
        
    }
}
