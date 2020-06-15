using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    [SerializeField] private float Speed = 2.5f;
    [SerializeField] private Rigidbody2D Phys;
    [SerializeField] private Vector2 movement;
    [SerializeField] private Vector2 mousePosit;
    [SerializeField] private Camera MouseCam;

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
