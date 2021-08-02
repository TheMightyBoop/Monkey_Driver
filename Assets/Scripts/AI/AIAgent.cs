using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateID initialState;
    public AIAgentConfig config;

    [HideInInspector] public AIStateMachine stateMachine;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Ragdoll ragdoll;
    [HideInInspector] public SkinnedMeshRenderer mesh;
    [HideInInspector] public UIHealthBar ui;
    [HideInInspector] public Transform playerTransform;
    [HideInInspector] public AIWeapons weapons;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UIHealthBar>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        weapons = GetComponent<AIWeapons>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIState_ChasePlayer());
        stateMachine.RegisterState(new AIState_Death());
        stateMachine.RegisterState(new AIState_Idle());
        stateMachine.RegisterState(new AIState_FindWeapon());
        stateMachine.RegisterState(new AIState_AttackPlayer());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }


}
