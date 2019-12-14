using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerController
{
    protected override void Move()
    {
        h = Input.GetAxis("Horizontal2");
        v = Input.GetAxis("Vertical2");

        transform.Translate(new Vector3(h, v, 0) * MoveFacter * Time.deltaTime);
    }

    protected override void Rotate()
    {
        JButton = Input.GetKey(KeyCode.RightControl);
        KButton = Input.GetKey(KeyCode.RightShift);

        if (JButton ^ KButton)
        {
            Vector3 euler = JButton ? Vector3.forward : Vector3.back;
            Light.Rotate(euler * RotateFacter);
        }
    }
}
