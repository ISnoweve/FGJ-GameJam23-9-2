using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class PlayerDestroy : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Destroy()
    {
        ani.SetTrigger("Die");
        Debug.Log("玩家死亡");
    }

}
