using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    Gun gun;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 movementDirection = Vector2.up;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gun = GetComponentInChildren<Gun>();
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        PauseButton();

        if (!GameManager.instance.PlayerAlive)
        {

            return;

        }


        if (GameManager.instance.Pause)
        {

        }
        else if (!GameManager.instance.Pause)
        {
            Shoot();
        }

    }
   
    void FixedUpdate()
    {
        if (!GameManager.instance.PlayerAlive)
            return;
        Move();
        if (GameManager.instance.Pause)
        {

        }
        else if (!GameManager.instance.Pause)
        {

        }


    }
    void PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.Pause)
                GameManager.instance.Pause = false;
            else
                GameManager.instance.Pause = true;
        }

    }
    void Move()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vetical = Input.GetAxis("Vertical");
        if (Horizontal != 0 || Vetical != 0)
        {
            ani.SetBool("Walk", true);

        }
        else
            ani.SetBool("Walk", false);

        Vector2 move = new Vector2(Horizontal, Vetical) * speed * Time.deltaTime;
        rb.velocity = move;

        if (move != Vector2.zero)
        {
            movementDirection = move.normalized;
        }

    }
    void FaceForward()
    {
        float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
            gun.Shoot();
    }

}


