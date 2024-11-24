using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private float sensitivity;
    private float mouseX;
    private float mouseY;
    private Vector2 rotation;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Invoker invoker;
    [SerializeField] private SpawnLogic spawner;

    public event UnityAction OnTargetHit;
    public event UnityAction OnRaiseButtonHit;
    public event UnityAction OnLowerButtonHit;
    public event UnityAction<int> OnStartButtonHit;
    public event UnityAction OnStopButtonHit;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        OnTargetHit += UIManager.instance.IncrementScore;
        OnRaiseButtonHit += RaiseDifficulty;
        OnLowerButtonHit += LowerDifficulty;
        OnStartButtonHit += spawner.StartSpawning;
        OnStopButtonHit += spawner.StopSpawning;
    }

    private void OnDisable()
    {
        OnTargetHit -= UIManager.instance.IncrementScore;
        OnRaiseButtonHit -= RaiseDifficulty;
        OnLowerButtonHit -= LowerDifficulty;
        OnStartButtonHit -= spawner.StartSpawning;
        OnStopButtonHit -= spawner.StopSpawning;
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
        RaycastHit hit;
        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.TransformDirection(Vector3.forward), out hit, 500)) 
        {
            if (hit.transform.CompareTag("Target")) OnTargetHit?.Invoke();

            if (hit.transform.CompareTag("RaiseButton")) OnRaiseButtonHit?.Invoke();
            if (hit.transform.CompareTag("LowerButton")) OnLowerButtonHit?.Invoke();

            //if (hit.transform.CompareTag("StartButton")) spawner.StartSpawning(UIManager.instance.activeDifficulty);
            if (hit.transform.CompareTag("StartButton")) OnStartButtonHit?.Invoke(UIManager.instance.activeDifficulty);
            //if (hit.transform.CompareTag("StopButton")) spawner.StopSpawning();
            if (hit.transform.CompareTag("StopButton")) OnStopButtonHit?.Invoke();
        }
    }

    private void RaiseDifficulty()
    {
        ICommand command = new RaiseDifficultyCommand();
        invoker.ExecuteCommand(command);
    }

    private void LowerDifficulty()
    {
        invoker.UndoCommand();
    }
}
