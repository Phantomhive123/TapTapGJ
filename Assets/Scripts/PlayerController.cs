using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    protected float moveFacter = 1;
    [SerializeField]
    protected float rotateFacter = 1;
    [SerializeField]
    protected float horizontalLimit = 15f;
    [SerializeField]
    protected float verticalLimit = 15f;

    protected float h = 0f;
    protected float v = 0f;
    private new Transform transform;
    protected bool JButton = false;
    protected bool KButton = false;

    [SerializeField]
    protected new Transform light = null;

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

        CheckBound();
        transform.Translate(new Vector3(h, v, 0) * moveFacter * Time.deltaTime);
    }

    protected virtual void Rotate()
    {
        JButton = Input.GetKey(KeyCode.J);
        KButton = Input.GetKey(KeyCode.K);

        if (JButton ^ KButton)
        {
            Vector3 euler = JButton ? Vector3.forward : Vector3.back;
            light.Rotate(euler * rotateFacter);
        }
    }

    protected void CheckBound()
    {
        if (transform.position.x >= horizontalLimit && h > 0)
            h = 0;
        else if (transform.position.x <= -horizontalLimit && h < 0)
            h = 0;
        if (transform.position.y >= verticalLimit && v > 0)
            v = 0;
        else if (transform.position.y <= -verticalLimit && v < 0)
            v = 0;
    }
}
