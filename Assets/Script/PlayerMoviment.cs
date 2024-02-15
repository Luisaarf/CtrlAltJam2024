using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField]private BoxCollider2D collider2d;
    [SerializeField]private SpriteRenderer skin;
    [SerializeField]private float walkSpeed;
    [SerializeField]private float runSpeed;


    //Camera
    [SerializeField]private float camSmoothing;
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
            Camera();
            Rotation();
        }
    }
    void Moviment(){
        moviment = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftShift)) speed = runSpeed; else speed = walkSpeed;

        transform.position += transform.right * moviment.x + transform.up * moviment.y;
    }

    public void Rotation(){
        if(moviment != Vector2.zero){
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moviment);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 2 * Time.deltaTime);

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
}
