using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private float coolTime = 0.25f;
    private float currentCoolTime;

    void Start()
    {
        currentCoolTime = 0;
    }
    void Update()
    {
        if (GameManager.instance.Pause)
        {

        }
        else if (!GameManager.instance.Pause)
        {
            FaceToMousePoint();
            CoolDown();
        }

    }
    void FaceToMousePoint()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 v = mouse - obj;
        v.z = 0;
        float angle = Vector3.SignedAngle(Vector3.up, v, Vector3.forward);
        Quaternion quaternion = Quaternion.Euler(0, 0, angle);
        transform.rotation = quaternion;
    }
    void CoolDown()
    {
        if (currentCoolTime >= 0)
        {
            currentCoolTime -= Time.deltaTime;
        }
        else return;

    }
    public void Shoot()
    {
        if (currentCoolTime < 0)
        {
            Instantiate(Bullet, shootPoint.position, shootPoint.rotation);
            currentCoolTime = coolTime;
            AudioManager.Instance.PlaySFX("Shoot");


        }
        else return;
    }


}
