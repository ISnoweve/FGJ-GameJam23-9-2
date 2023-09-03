using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossState currentState = BossState.Sleep;
    void Start()
    {

    }

    void Update()
    {
        switch (currentState)
        {
            case BossState.Sleep:
                break;
            case BossState.Idle:
                break;
            case BossState.Patrol:
                break;
            case BossState.Chase:
                break;
            case BossState.Attack:
                break;
            case BossState.Dead:
                break;
        }
    }
}
