using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected float MoveFacter = 1;
    [SerializeField]
    protected float RotateFacter = 1;
    [SerializeField]
    private float RadiusOfSight = 0f;
    [SerializeField][Range(1,5)]
    private float LengthLightTimes = 2f;

    protected float h = 0f;
    protected float v = 0f;
    private new Transform transform;
    protected bool JButton = false;
    protected bool KButton = false;

    [SerializeField]
    protected Transform Scope = null;
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

    protected virtual void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, v, 0) * MoveFacter * Time.deltaTime);
    }

    protected virtual void Rotate()
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
