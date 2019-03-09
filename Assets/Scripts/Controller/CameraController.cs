using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{

    public enum CAMERAMODE
    {
        RTS,
        FlyCamera
    }

    public float ScreenEdgeBorderThickness = 5.0f; // distance from screen edge. Used for mouse movement

    [Header("Camera Mode")]
    [Space]
    public CAMERAMODE CameraMode = CAMERAMODE.RTS;
    public bool MouseBorderMovement = true;

    [Header("Movement Speeds")]
    [Space]
    public float minPanSpeed;
    public float maxPanSpeed;
    public float secToMaxSpeed; //seconds taken to reach max speed;
    public float zoomSpeed;

    [Header("Movement Limits")]
    [Space]
    public bool enableMovementLimits;
    public Vector2 heightLimit;
    public Vector2 lenghtLimit;
    public Vector2 widthLimit;
    private Vector2 zoomLimit;

    private float panSpeed;
    private Vector3 initialPos;
    private Vector3 panMovement;
    private Vector3 pos;
    private Quaternion rot;
    private bool rotationActive = false;
    private Vector3 lastMousePosition;
    private Quaternion initialRot;
    private float panIncrease = 0.0f;

    [Header("Rotation")]
    [Space]
    public bool rotationEnabled;
    public float rotateSpeed;


    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        zoomLimit.x = 15;
        zoomLimit.y = 65;
    }


    void Update()
    {
        //Movement
        if (!this.rotationActive && !EventSystem.current.IsPointerOverGameObject())
        {
            SetPanMovement();
        }

        //Zoom
        Camera.main.fieldOfView -= Input.mouseScrollDelta.y * this.zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, this.zoomLimit.x, this.zoomLimit.y);

        //Rotation
        if (this.rotationEnabled)
        {
            GetMouseRotation();
        }
        else
        {
            this.rotationActive = false;
        }

        //Boundaries
        if (enableMovementLimits == true)
        {
            //movement limits
            this.pos = this.transform.position;
            this.pos.y = Mathf.Clamp(this.pos.y, this.heightLimit.x, this.heightLimit.y);
            this.pos.z = Mathf.Clamp(this.pos.z, this.lenghtLimit.x, this.lenghtLimit.y);
            this.pos.x = Mathf.Clamp(this.pos.x, this.widthLimit.x, this.widthLimit.y);
            this.transform.position = pos;
        }
    }

    //Set Mouse Rotation
    private void GetMouseRotation()
    {
        // Mouse Rotation
        if (Input.GetMouseButton(0))
        {
            this.rotationActive = true;
            Vector3 mouseDelta;
            if (this.lastMousePosition.x >= 0 &&
                this.lastMousePosition.y >= 0 &&
                this.lastMousePosition.x <= Screen.width &&
                this.lastMousePosition.y <= Screen.height)
                mouseDelta = Input.mousePosition - this.lastMousePosition;
            else
            {
                mouseDelta = Vector3.zero;
            }
            var rotation = Vector3.up * Time.deltaTime * this.rotateSpeed * mouseDelta.x;
            rotation += Vector3.left * Time.deltaTime * this.rotateSpeed * mouseDelta.y;

            transform.Rotate(rotation, Space.World);

            // Make sure z rotation stays locked
            rotation = transform.rotation.eulerAngles;
            rotation.z = 0;
            transform.rotation = Quaternion.Euler(rotation);
        }

        if (Input.GetMouseButtonUp(0))
        {
            rotationActive = false;
            if (this.CameraMode == CAMERAMODE.RTS) transform.rotation = Quaternion.Slerp(transform.rotation, initialRot, 0.5f * Time.time);
        }

        lastMousePosition = Input.mousePosition;
    }

    //Set Camera panning
    private void SetPanMovement()
    {
        this.panMovement = Vector3.zero;

        float lengthPanValue = Input.GetAxis("LengthPan");
        float widthPanValue = Input.GetAxis("WidthPan");
        float heightPanValue = Input.GetAxis("HeightPan");

        bool moveForward = lengthPanValue > 0 || (MouseBorderMovement && Input.mousePosition.y >= Screen.height - this.ScreenEdgeBorderThickness && Input.mousePosition.y <= Screen.height);
        bool moveBackward = lengthPanValue < 0 || (MouseBorderMovement && Input.mousePosition.y <= this.ScreenEdgeBorderThickness && Input.mousePosition.y >= 0);
        bool moveLeft = widthPanValue < 0 || (MouseBorderMovement && Input.mousePosition.x <= this.ScreenEdgeBorderThickness && Input.mousePosition.x >= 0);
        bool moveRight = widthPanValue > 0 || (MouseBorderMovement && Input.mousePosition.x >= Screen.width - this.ScreenEdgeBorderThickness && Input.mousePosition.x <= Screen.width);
        bool moveUp = heightPanValue < 0;
        bool moveDown = heightPanValue > 0;

        if (moveForward)
        {
            //Move Forward
            this.panMovement += Vector3.forward * this.panSpeed * Time.deltaTime;
        }
        else if (moveBackward)
        {
            //Move Backward
            this.panMovement -= Vector3.forward * this.panSpeed * Time.deltaTime;
        }

        if (moveLeft)
        {
            //Move Left
            this.panMovement += Vector3.left * this.panSpeed * Time.deltaTime;
        }
        else if (moveRight)
        {
            //Move Right
            this.panMovement += Vector3.right * this.panSpeed * Time.deltaTime;
        }

        if (moveUp)
        {
            //Rotate Up
            this.panMovement += Vector3.up * this.panSpeed * Time.deltaTime;
        }
        else if (moveDown)
        {
            //Rotate Down
            this.panMovement += Vector3.down * this.panSpeed * Time.deltaTime;
        }

        if (this.CameraMode == CAMERAMODE.RTS)
        {
            this.transform.Translate(this.panMovement, Space.World);
        }
        else
        {
            this.transform.Translate(this.panMovement, Space.Self);
        }

        //increase pan speed
        if (moveForward
            || moveBackward
            || moveLeft
            || moveRight
            || moveUp
            || moveDown)
        {
            if (this.secToMaxSpeed != 0)
            {
                this.panIncrease += Time.deltaTime / this.secToMaxSpeed;
                this.panSpeed = Mathf.Lerp(this.minPanSpeed, this.maxPanSpeed, this.panIncrease);
            }
            else
            {
                this.panSpeed = this.maxPanSpeed;
            }
        }
        else
        {
            this.panIncrease = 0;
            this.panSpeed = this.minPanSpeed;
        }
    }
}
