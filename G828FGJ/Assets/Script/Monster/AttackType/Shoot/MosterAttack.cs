using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttack : MonoBehaviour
{
    [SerializeField] private MonsterGun MonsterAttack;

    public int burstCount;
    private bool isShoot;
    private void Awake()
    {
        MonsterAttack = GetComponentInChildren<MonsterGun>();
    }
    private void Start()
    {
        isShoot = false;
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.Pause)
        {
            return;
        }

        bool timeToMove = MonsterJudgeZone.Instance.isInMoveZone;
        bool timeToAttack = MonsterJudgeZone.Instance.isInAttackZone;

        if (timeToMove == true && timeToAttack == true && isShoot == false)
        {
            StartCoroutine(ShootBurst());
        }
        else
        {
            return;
        }
    }

    IEnumerator ShootBurst()
    {
        isShoot = true;
        for (int i = 0; i < burstCount; i++)
        {
            MonsterAttack.Shoot();
            Debug.Log("MakeSureBurst");
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2);
        isShoot = false;
    }
}
