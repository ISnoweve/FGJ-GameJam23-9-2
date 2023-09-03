using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleTrigger : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject PressUI = GameObject.Find("PressUI");
            PressUI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Boss boss = FindObjectOfType<Boss>();
                boss.StartBattle = true;
                Destroy(gameObject);

            }


        }

    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject PressUI = GameObject.Find("PressUI");
            PressUI.SetActive(false);

        }
    }
}
