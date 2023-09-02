using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] private GameObject dieSprite;

    public void Destroy()
    {
        GameManager.instance.enemyDie += 1;
        Instantiate(dieSprite, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
