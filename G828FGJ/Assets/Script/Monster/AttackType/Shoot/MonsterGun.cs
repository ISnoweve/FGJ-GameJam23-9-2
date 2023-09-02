using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGun : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform shootPoint;
    public void Shoot()
    {
        Instantiate(Bullet, shootPoint.position, shootPoint.rotation);

    }
}
