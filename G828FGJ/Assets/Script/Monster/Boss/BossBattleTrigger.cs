using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleTrigger : MonoBehaviour
{

    [SerializeField] private bool isBossBattle;

    int hp = 5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
                if (isBossBattle)
                {
                    Boss boss = FindObjectOfType<Boss>();
                    boss.StartBattle = true;
                }

            }

        }
    }
}
