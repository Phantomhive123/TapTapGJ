using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerController
{
    protected override void Move()
    {
        h = Input.GetAxis("Horizontal2");
        v = Input.GetAxis("Vertical2");

        CheckBound();
        transform.Translate(new Vector3(h, v, 0) * moveFacter * Time.deltaTime);
    }

    protected override void Rotate()
    {
        JButton = Input.GetKey(KeyCode.Keypad4);
        KButton = Input.GetKey(KeyCode.Keypad5);

        if (JButton ^ KButton)
        {
            Vector3 euler = JButton ? Vector3.forward : Vector3.back;
            light.Rotate(euler * rotateFacter);
        }
    }
}
