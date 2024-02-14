using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField]private BoxCollider2D collider2d;
    [SerializeField]private float walkSpeed;
    [SerializeField]private float runSpeed;
    [SerializeField]private Camera cam;
    

    bool isLocked = true;
    float speed;
    Vector2 moviment;
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();    
        speed = walkSpeed;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) isLocked = !isLocked;  
        if(isLocked){
            Moviment();
        }
    }
    void Moviment(){
        moviment = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        transform.position += transform.right * moviment.x + transform.up * moviment.y;
    }
}
