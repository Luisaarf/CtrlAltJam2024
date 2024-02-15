using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField]private BoxCollider2D collider2d;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private float walkSpeed;
    [SerializeField]private float runSpeed;
    [SerializeField]private float rotationSpeed;
    //dash
    [SerializeField]private Slider dashLoadUI;
    [SerializeField]private float time;
    [SerializeField]private float timeMultiplier;
    [SerializeField]private float dashForce;


    //Camera
    [SerializeField]private float camSmoothing;
    [SerializeField]private Camera cam;
    bool isLocked = true;
    float speed;
    Vector2 moviment;
    Vector2 smoothMoviment;
    Vector2 smoothMovimentVelocity;
    void Start()
    {
        collider2d = GetComponent<BoxCollider2D>();    
        rb = GetComponent<Rigidbody2D>();
        speed = walkSpeed;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) isLocked = !isLocked;  
        if(isLocked){
            Moviment();
            Camera();
            Rotation();
            Dash();
        }
    }
    void Moviment(){
        moviment = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if(Input.GetKey(KeyCode.LeftShift)) speed = runSpeed; else speed = walkSpeed;

        //transform.position += transform.right * moviment.x + transform.up * moviment.y;
        rb.velocity = moviment  * speed;
    }

    public void Rotation(){
        if(moviment != Vector2.zero){
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moviment);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = rotation;
        }
    }

    public void Camera(){
        float xTarget = transform.position.x ;
        float yTarget = transform.position.y;

        float xNew = Mathf.Lerp(cam.transform.position.x, xTarget, Time.deltaTime * camSmoothing);
        float yNew = Mathf.Lerp(cam.transform.position.y, yTarget, Time.deltaTime * camSmoothing);

        cam.transform.position = new Vector3(xNew, yNew, cam.transform.position.z);
    }

    public void Dash(){
        if(Input.GetKey(KeyCode.E)){
            if(time <= 100 )time += timeMultiplier * Time.deltaTime;
        }

        dashLoadUI.value = time;

        if(Input.GetKeyUp(KeyCode.E)) {
            rb.AddForce(transform.up * (dashForce * time));
            time = 0;
            dashLoadUI.value = 0;
        }

    }
}
