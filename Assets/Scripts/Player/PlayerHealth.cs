using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    Ragdoll ragdoll;

    protected override void OnStart()
    {
        ragdoll = GetComponent<Ragdoll>();
    }

    protected override void OnDeath(Vector3 direction)
    {
        ragdoll.ActivateRagdoll();
    }

    protected override void OnDamage(Vector3 direction)
    {

    }
}
