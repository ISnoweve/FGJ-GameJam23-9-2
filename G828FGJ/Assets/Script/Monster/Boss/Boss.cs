using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Boss : MonoBehaviour
{
    public BossState currentState = BossState.Sleep;
    public bool StartBattle = false;
    private bool hasCoroutineStarted = false;
    [SerializeField] private float detectRange;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float HP;
    [SerializeField] private GameObject bullet;


    Animator ani;
    GameObject player;
    void Awake()
    {
        ani = GetComponent<Animator>();
    }
    void Start()
    {
        currentState = BossState.Sleep;
    }

    void Update()
    {
        switch (currentState)
        {
            case BossState.None:

                break;
            case BossState.Sleep:
                Sleep();
                break;
            case BossState.Idle:
                Idle();
                break;
            case BossState.Shoot:
                FaceToPlayerPoint();
                if (!hasCoroutineStarted)
                    StartCoroutine(Shoot());
                break;
            case BossState.Chase:
                FaceToPlayerPoint();
                if (!hasCoroutineStarted)
                    StartCoroutine(Chase());

                break;
            case BossState.Dead:
                Dead();
                break;
        }
    }
    void Sleep()
    {
        if (StartBattle)
            currentState = BossState.Idle;

    }
    void Idle()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= detectRange)
        {
            int num = Random.Range(3, 5);//shoot or chase
            currentState = (BossState)num;
            return;
        }
    }
    IEnumerator Shoot()
    {
        hasCoroutineStarted = true;
        Debug.Log("Shoot");

        for (int i = 0; i < 5; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }

        currentState = BossState.Idle;
        hasCoroutineStarted = false;
        yield return null;


    }
    IEnumerator Chase()
    {
        hasCoroutineStarted = true;
        Debug.Log("Chase");


        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        yield return new WaitForSeconds(1);


        currentState = BossState.Idle;
        hasCoroutineStarted = false;
        yield return null;
    }
    void Dead()
    {

    }
    void FaceToPlayerPoint()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        Vector3 v = (player.transform.position - transform.position).normalized;
        v.z = 0;
        this.transform.up = v;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
