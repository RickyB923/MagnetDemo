using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The main variables and components of the Player
    private Utilities utilities = new Utilities();
    [SerializeField] float speed;
    [SerializeField] float maxVelocity;
    [Header ("1 = Positive, -1 = Negative")]
    public float polarity;
    public Vector3 lastPosition;
    private Camera cam;
    public Rigidbody rb;
    public SphereCollider field;
    private MeshRenderer fieldRenderer;
    [Header("The materials for the magnetic fields")]
    [SerializeField] Material posFieldMat;
    [SerializeField] Material negFieldMat;
    // Input variables
    private float rightLeftInput;
    private float forwardBackInput;
    private float magInput;
    public bool pauseInput = false;
    public Vector2 mouseInput;
    void Start() // Initializes components
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = this.GetComponentInChildren<Camera>();
        rb = this.GetComponent<Rigidbody>();
        rb.mass = utilities.CalculateMass(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        field = this.GetComponentInChildren<SphereCollider>();
        fieldRenderer = field.GetComponent<MeshRenderer>();
    }
    void Update() // Resets certain variables every frame
    {
        var currentPosition = transform.position;
        GetMoveInput();
        polarity = magInput;
        lastPosition = currentPosition;
    }
    void FixedUpdate() // Resets the magnetic field effect and clamps Rigidbody velocity
    {
        fieldRenderer.enabled = false;
        Move();
        Vector3 vector = utilities.ClampVelocity(rb, maxVelocity);
        rb.AddForce(vector,ForceMode.Impulse);
    }
    void GetMoveInput() // Gets the values for player's inputs
    {
        rightLeftInput = Input.GetAxis("Horizontal");
        forwardBackInput = Input.GetAxis("BackNForth");
        magInput = Input.GetAxis("Magnet");
        mouseInput.x += Input.GetAxis("Mouse X");
        mouseInput.y += Input.GetAxis("Mouse Y");
        mouseInput.y = Mathf.Clamp(mouseInput.y,-5,10);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseInput = !pauseInput;
        }
    }
    void Move() // Enacts the player's inputs (movement, magnets, carmera controls)
    {
        // Directional movement
        if(rightLeftInput == 1)
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * speed);
        }
        if(rightLeftInput == -1)
        {
            transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);
        }
        if(forwardBackInput == 1)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
        }
        if(forwardBackInput == -1)
        {
            transform.Translate(Vector3.back * Time.fixedDeltaTime * speed);
        }
        // Magnetic field control 
        if(magInput == 1)
        {
            polarity = magInput;
            fieldRenderer.enabled = true;
            fieldRenderer.material = posFieldMat;
        }        
        if(magInput == -1)
        {
            polarity = magInput;
            fieldRenderer.enabled = true;
            fieldRenderer.material = negFieldMat;
        }
        // Mouse controlled camera movement
        cam.transform.localRotation = Quaternion.Euler(mouseInput.y,0,0);
        transform.localRotation = Quaternion.Euler(0,mouseInput.x,0); 
    }
}
