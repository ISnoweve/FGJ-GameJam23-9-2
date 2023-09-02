using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDestroy : MonoBehaviour
{
    [SerializeField] private GameObject dieSprite;

    public void Destroy()
    {
        Instantiate(dieSprite, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

}
