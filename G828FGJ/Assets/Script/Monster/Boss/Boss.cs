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
        ani = GetComponentInParent<Animator>();
    }
    void Start()
    {
        currentState = BossState.Sleep;
    }

    void Update()
    {

        if (GameManager.instance.Pause)
            return;
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
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);

                if (!hasCoroutineStarted)
                    StartCoroutine(Chase());

                break;
            case BossState.RotateShoot:

                if (!hasCoroutineStarted)
                {
                    StartCoroutine(RotateShoot1());
                    StartCoroutine(RotateShoot2());
                }
                break;
            case BossState.AroundShoot:

                if (!hasCoroutineStarted)
                    StartCoroutine(AroundShoot());
                break;
            case BossState.Dead:
                Dead();
                break;
        }
    }
    void Sleep()
    {
        if (StartBattle)
        {
            AudioManager.Instance.PlayBGM("Boss");
            currentState = BossState.Idle;

        }

    }
    void Idle()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= detectRange)
        {
            int num = Random.Range(3, 7);//shoot or chase or rotateShoot or aroundShoot
            currentState = (BossState)num;
            return;
        }
    }
    IEnumerator Shoot()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Shoot");

        for (int i = 0; i < 10; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            AudioManager.Instance.PlaySFX("Bang");

            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            AudioManager.Instance.PlaySFX("Bang");

            yield return new WaitForSeconds(0.1f);
        }
        currentState = BossState.Chase;
        hasCoroutineStarted = false;
        yield return null;


    }
    IEnumerator RotateShoot1()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Shoot");
        int angle = 0;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + 180));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + 180));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + 180));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }

        currentState = BossState.Chase;
        hasCoroutineStarted = false;
        yield return null;


    }
    IEnumerator RotateShoot2()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Shoot");
        int angle = 0;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
            yield return new WaitForSeconds(0.05f);
        }

        currentState = BossState.Chase;
        hasCoroutineStarted = false;
        yield return null;


    }
    IEnumerator AroundShoot()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Shoot");
        int angle = 0;
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
        }
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
        }
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + 12));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
        }
        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < 15; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle + 12));
            AudioManager.Instance.PlaySFX("Bang");
            angle += 24;
        }

        currentState = BossState.Chase;
        hasCoroutineStarted = false;
        yield return null;


    }
    IEnumerator Chase()
    {
        hasCoroutineStarted = true;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Chase");

        chaseSpeed += 3;
        yield return new WaitForSeconds(0.5f);

        chaseSpeed -= 3;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Chase");

        chaseSpeed += 3;
        yield return new WaitForSeconds(0.5f);

        chaseSpeed -= 3;
        currentState = BossState.Idle;
        hasCoroutineStarted = false;
        yield return null;
    }
    void Dead()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP -= 1;
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
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
