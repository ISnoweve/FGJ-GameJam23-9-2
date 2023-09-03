using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShootMove : MonoBehaviour
{
    [SerializeField] private SpriteRenderer textureFlip;
    private MonsterJudgeZone monsterJudgeZone;

    public GameObject player;
    public float moveSpeed;
    public GameObject pivot;

    private void Awake()
    {
        monsterJudgeZone = GetComponentInChildren<MonsterJudgeZone>();
    }
    void Update()
    {
        Flip();
    }
    private void FixedUpdate()
    {
        if (GameManager.instance.Pause)
        {
            return;
        }

        bool timeToMove = monsterJudgeZone.isInMoveZone;
        bool timeToAttack = monsterJudgeZone.isInAttackZone;

        player = monsterJudgeZone.objectInZone;

        pivot.transform.up = LookAtPlayer();

        if (timeToMove == true && timeToAttack == false)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            //Debug.Log("moving");
        }
        else
        {
            return;
        }
    }

    private Vector3 LookAtPlayer()
    {
        Vector3 rotate = (player.transform.position - transform.position).normalized;

        if (rotate.x <= 0)
        {
            textureFlip.flipX = true;
        }
        else if (rotate.x >= 0)
        {
            textureFlip.flipX = false;
        }
        return new Vector3(rotate.x,rotate.y,0);
    }
    void Flip()
    {
        
    }

}
