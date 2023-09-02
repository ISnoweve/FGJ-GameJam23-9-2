using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSmash : MonoBehaviour
{
    [SerializeField] private MonsterSmashMove monsterMove;
    [SerializeField] private MonsterJudgeZone monsterJudgeZone;

    public bool isSmash;
    public int dashSpeed;

    private void Awake()
    {
        monsterMove = GetComponentInChildren<MonsterSmashMove>();
        monsterJudgeZone = GetComponentInChildren<MonsterJudgeZone>();
    }

    private void Start()
    {
        isSmash = false;
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.Pause)
        {
            return;
        }

        bool timeToMove = monsterJudgeZone.isInMoveZone;
        bool timeToAttack = monsterJudgeZone.isInAttackZone;

        if (timeToMove == true && timeToAttack == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, monsterMove.player.transform.position, monsterMove.moveSpeed * Time.deltaTime);
            if(isSmash == false)
            {
                StartCoroutine(Smash());
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator Smash()
    {
        isSmash = true;

        monsterMove.moveSpeed += dashSpeed;
        yield return new WaitForSeconds(0.2f);
        monsterMove.moveSpeed -= dashSpeed;
        Debug.Log("MakeSureSmash");
        yield return new WaitForSeconds(3);

        isSmash = false;
    }
}
