using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject UIObject;
    [SerializeField] private GameObject CameraObject;

    public int enemyDie;
    public bool Pause;
    //---------------
    private Vector3 currentCamPos;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        Pause = false;
        enemyDie = 0;
    }

    void Update()
    {
        UIObject.SetActive(Pause);
        if (Pause)
        {
            var vcam = CameraObject.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = null;
            CameraObject.transform.position = currentCamPos;
        }
        else
        {
            var vcam = CameraObject.GetComponent<CinemachineVirtualCamera>();
            vcam.Follow = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            currentCamPos = CameraObject.transform.position;
        }

    }


}
