using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 8f;

    [SerializeField]
    float rotationSpeed = 100f;

    float thrustForce = 3f;

    Rigidbody2D rb;

    [Header("For Mouse Rotation")]
    [SerializeField]
    bool mouseRot = true;

    Vector3 mouseScreenPosition = Vector3.zero;
    float AngleRad = 0;
    float AngleDeg = 0;
    
    Camera cam;


    Vector2 SpawnPosition;

    //границы видимости камеры
    Vector3 leftBot, rightTop;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        
        
        Vector3 cameraToObject = transform.position - cam.transform.position;
        float distance = Vector3.Project(cameraToObject, cam.transform.forward).z;

        //Левый нижний угол камеры
        leftBot = cam.ViewportToWorldPoint(new Vector3(0, 0, distance));
        //Правый верхний угол камеры
        rightTop = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));

        
    }

    void FixedUpdate () {
        if(!mouseRot){
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }

        else{
            mouseScreenPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            AngleRad = Mathf.Atan2(mouseScreenPosition.y - transform.position.y, mouseScreenPosition.x - transform.position.x);
            AngleDeg = (180 / Mathf.PI) * AngleRad;
            transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 90);
        }

        rb.AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));

        float x_left  = leftBot.x;
        float x_right = rightTop.x;
        float y_top   = rightTop.y;
        float y_bot   = leftBot.y;

        if(transform.localPosition.y > y_top){
            transform.localPosition = new Vector3(transform.localPosition.x, y_bot,0);
        }
        if(transform.localPosition.y < y_bot){
            transform.localPosition = new Vector3(transform.localPosition.x, y_top,0);
        }
        if(transform.localPosition.x > x_right){
            transform.localPosition = new Vector3(x_left, transform.localPosition.y,0);
        }
        if(transform.localPosition.x < x_left){
            transform.localPosition = new Vector3(x_right, transform.localPosition.y,0);
        }
    }
}
