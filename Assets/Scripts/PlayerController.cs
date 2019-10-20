using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerController : MonoBehaviour {

    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    [Range(1f, 100f)] [SerializeField] float rotationSpeed = 1f;
    [Range(1f, 1000f)] [SerializeField] float force = 800.0f;
    [Range(1, 10)] public float jumpVelocity = 5.0f;

    float distance = 8f;

    Rigidbody[] rigidbodies;
    Rigidbody rb;
    Animator animator;
    
    public LayerMask defaultLayer;
    public LayerMask enemyLayer;

    bool onTheGround;

    [SerializeField] public Camera mainCamera;
    [SerializeField] public  Camera cameraTwo;

    [SerializeField] GameObject bulletPrefab;

    public bool PlayerCanMove;

    void Awake()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        mainCamera.enabled = true;
        cameraTwo.enabled = false;

        ToggleKinematics(true);

        PlayerCanMove = true;
    }


    private void FixedUpdate()
    {
        PlayerRayCast();

        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            Jump();
            onTheGround = false;
        }
    }


    private void Update()
    {
        if (PlayerCanMove)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * rotationSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 2.0f * movementSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            bool isWalkingPressed = Input.GetAxis("Vertical") > 0 ? true : false;
            bool isBackwardgPressed = Input.GetAxis("Vertical") < 0 ? true : false;

            animator.SetBool("isWalking", isWalkingPressed);
            animator.SetBool("isMoveBack", isBackwardgPressed);

            if (Input.GetMouseButtonDown(0))
            {
                var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                position = mainCamera.ScreenToWorldPoint(position);
                var bulletInstance = Instantiate(bulletPrefab, transform.position + transform.up * 1.4f + transform.forward * 0.6f, Quaternion.identity) as GameObject;

                bulletInstance.transform.LookAt(position);
                var bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();
                bulletRigidBody.AddForce(bulletInstance.transform.forward * force);

            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isMoveBack", false);
        }
        
    }

    void ToggleKinematics(bool toggle)
    {
        foreach (var rigidbody in rigidbodies)
        {
            if (rigidbody != GetComponent<Rigidbody>())
            {
                rigidbody.isKinematic = toggle;
            }
        }

        animator.enabled = toggle;
    }

    void CameraTwo(bool cameraSwitch)
    {
        if (cameraSwitch)
        {
            if (mainCamera.enabled)
            {
                cameraTwo.enabled = true;
                mainCamera.enabled = false;
            }
        }
        else
        {
            if (!mainCamera.enabled)
            {
                cameraTwo.enabled = false;
                mainCamera.enabled = true;
            }
        }
    }

    void PlayerRayCast()
    {
        int layerMask = 1 << 12;

        RaycastHit hit;
        Vector3 rayOrigin = new Vector3(0, 1.7f, 0);

        var rayForward = Physics.Raycast(transform.position + rayOrigin, transform.TransformDirection(Vector3.forward), out hit, 2.0f, layerMask);
        var rayBackward = Physics.Raycast(transform.position + rayOrigin, transform.TransformDirection(Vector3.back), out hit, 2.0f, layerMask);
        var rayUp = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 1.7f, layerMask);

        if (rayForward || rayUp || rayBackward)
        {
            animator.SetBool("isSneaking", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isMoveBack", false);
            if (rayUp)
                CameraTwo(true);
            else
                CameraTwo(false);
        }
        else
        {
            animator.SetBool("isSneaking", false);
            CameraTwo(false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        onTheGround = OverlapCapsule(defaultLayer);

        if (OverlapCapsule(enemyLayer))
        {
            ToggleKinematics(false);
            Invoke("GetUp", 3.0f);
        }
    }

    void GetUp()
    {
        ToggleKinematics(true);
        animator.Play("GetUp");
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
    }

    bool OverlapCapsule(LayerMask layer)
    {
        var hitCollider = Physics.OverlapCapsule(transform.position + new Vector3(0, 0.5f, 0), transform.position + new Vector3(0, 1.5f, 0), 1f, layer);

        if (hitCollider.Length > 0)
            return true;
        else
            return false;
    }

   
}
