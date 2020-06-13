using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float Speed = 2.5f;
    public Rigidbody2D Phys;
    private Vector2 movement;
    private Vector2 mousePosit;
    public Camera MouseCam;

    void Start()
    {
        //Cursor.visible = false; 
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosit = MouseCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() 
    {
        Phys.MovePosition(Phys.position + movement * Speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosit - Phys.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        Phys.rotation = angle;
    }
}
