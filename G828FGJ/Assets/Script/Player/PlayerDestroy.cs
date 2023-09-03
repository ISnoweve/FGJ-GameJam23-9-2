using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class PlayerDestroy : MonoBehaviour
{
    bool coutDie;
    Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
        coutDie = false;
    }

    public void Destroy()
    {
        if (coutDie)return;
        AudioManager.Instance.PlaySFX("Die");
        ani.SetTrigger("Die");
        GameManager.instance.PlayerAlive = false;
            StartCoroutine(Resurrection());
        Debug.Log("玩家死亡");
    }
    IEnumerator Resurrection()
    {
        coutDie = true;
        yield return new WaitForSecondsRealtime(2);
        GameManager.instance.PlayerAlive = true;
        coutDie = false;
        yield return null;
    }
    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (coutDie == false)

                Destroy();
        }
    }
}
