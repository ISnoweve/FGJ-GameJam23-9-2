using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSmash : MonoBehaviour
{
    [SerializeField] private MonsterSmashMove monsterMove;

    public bool isSmash;
    public int dashSpeed;

    private void Awake()
    {
        monsterMove = GetComponentInChildren<MonsterSmashMove>();
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

        bool timeToMove = MonsterJudgeZone.Instance.isInMoveZone;
        bool timeToAttack = MonsterJudgeZone.Instance.isInAttackZone;

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
