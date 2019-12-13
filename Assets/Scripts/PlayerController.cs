using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MoveFacter = 1;
    [SerializeField]
    private float RotateFacter = 1;
    [SerializeField]
    private float RadiusOfSight = 0f;
    [SerializeField][Range(1,5)]
    private float LengthLightTimes = 2f;

    private float h = 0f;
    private float v = 0f;
    private new Transform transform;
    private bool JButton = false;
    private bool KButton = false;

    [SerializeField]
    private Transform Scope = null;
    [SerializeField]
    private Transform Children = null;


    private void Start()
    {
        transform = GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, v, 0) * MoveFacter * Time.deltaTime);
    }

    private void Rotate()
    {
        JButton = Input.GetKey(KeyCode.J);
        KButton = Input.GetKey(KeyCode.K);

        if (JButton ^ KButton)
        {
            Vector3 euler = JButton ? Vector3.forward : Vector3.back;
            Scope.Rotate(euler * RotateFacter);
        }
    }
}
