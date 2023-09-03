using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAttack : MonoBehaviour
{
    [SerializeField] private MonsterGun MonsterAttack;
    [SerializeField] private MonsterJudgeZone monsterJudgeZone;

    public int cooltime;
    public int burstCount;
    public bool isShoot;
    private void Awake()
    {
        MonsterAttack = GetComponentInChildren<MonsterGun>();
        monsterJudgeZone = GetComponentInChildren<MonsterJudgeZone>();
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

        bool timeToMove = monsterJudgeZone.isInMoveZone;
        bool timeToAttack = monsterJudgeZone.isInAttackZone;

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
            AudioManager.Instance.PlaySFX("Bang");
            Debug.Log("MakeSureBurst");
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(cooltime);
        isShoot = false;
    }
}
