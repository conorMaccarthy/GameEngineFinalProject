using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private float sensitivity;
    private float mouseX;
    private float mouseY;
    private Vector2 rotation;

    [SerializeField] private float moveSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraMovement();
        PlayerMovement();

        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    private void CameraMovement()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotation.y += mouseX;
        rotation.x -= mouseY;

        rotation.x = Mathf.Clamp(rotation.x, -90, 90);

        transform.eulerAngles = new Vector3(0, rotation.y, 0);
        gameCamera.transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0);
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);
    }

    private void Shoot()
    {
        Debug.Log("shoot");
        //Debug.DrawRay(gameCamera.transform.position, gameCamera.transform.TransformDirection(Vector3.forward) * 500, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 500)) 
        {
            if (hit.transform.CompareTag("Target")) Destroy(hit.transform.gameObject);
        }
    }
}
