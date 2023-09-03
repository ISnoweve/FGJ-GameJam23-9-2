using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJudgeZone : MonoBehaviour
{

    [SerializeField] private GameObject Mosnter;
    [SerializeField] private GameObject moveJudgePosition;
    [SerializeField] private GameObject attackJudgePosition;

    public GameObject objectInZone;
    public bool isInMoveZone;
    public bool isInAttackZone;

    #region UnityThings
    private void Start()
    {
        isInMoveZone = false;
        objectInZone = GameObject.FindGameObjectWithTag("Player");
        isInAttackZone = false;
    }
    private void Update()
    {
        isInMoveZone = MovementZone();
        isInAttackZone = AttackZone();
    }
    private void FixedUpdate()
    {
        //MonsterAction(isInMoveZone, isInAttackZone);
    }
    #endregion

    //���ե�
    private void MonsterAction(bool moveJudge, bool attackJudge)
    {
        if (moveJudge == true && attackJudge == false)
        {
            Debug.Log("Moving");
        }
        else if (moveJudge == true && attackJudge == true)
        {
            Debug.Log("Attacking");
        }
    }
    private bool MovementZone()
    {
        Vector3 monsterVector = transform.position;
        Vector3 moveJudgeVector = moveJudgePosition.transform.position;
        float moveJudgeZone = Vector3.Distance(monsterVector, moveJudgeVector);

        // �p�⪱�a�PmoveJudgeVector���Z��
        float playerDistance = Vector3.Distance(objectInZone.transform.position, monsterVector);

        // �p�G���a�Z���bmoveJudgeZone���A�h����ާ@
        if (moveJudgeZone >= playerDistance)
        {
            return true;
        }
        else
        {

            return false;
        }
    }
    private bool AttackZone()
    {
        Vector3 monsterVector = transform.position;
        Vector3 attackJudgeVector = attackJudgePosition.transform.position;
        float attackJudgeZone = Vector3.Distance(monsterVector, attackJudgeVector);

        // �p�⪱�a�PmoveJudgeVector���Z��
        float playerDistance = Vector3.Distance(objectInZone.transform.position, monsterVector);

        // �p�G���a�Z���bmoveJudgeZone���A�h����ާ@
        if (attackJudgeZone >= playerDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmos()
    {

       UnityEditor.Handles.color = Color.yellow;

       Vector3 monsterVector = transform.position;
       Vector3 moveJudgeVector = moveJudgePosition.transform.position;
       Vector3 attackJudgeVector = attackJudgePosition.transform.position;

       float moveJudgeZone = Vector3.Distance(monsterVector, moveJudgeVector);
       float attackJudgeZone = Vector3.Distance(monsterVector, attackJudgeVector);

       UnityEditor.Handles.DrawWireDisc(monsterVector, Vector3.back, moveJudgeZone);
       UnityEditor.Handles.DrawWireDisc(monsterVector, Vector3.back, attackJudgeZone);
    }
}
