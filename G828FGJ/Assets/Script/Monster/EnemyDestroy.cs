using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class EnemyDestroy : MonoBehaviour
{
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Destroy()
    {
        ani.SetTrigger("Die");
        GameManager.instance.enemyDie += 1;
        Destroy(this.gameObject, 1.5f);
    }

}
