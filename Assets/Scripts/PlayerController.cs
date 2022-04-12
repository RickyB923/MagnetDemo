using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public float weight;
    [Header ("1 = Positive, -1 = Negative")]
    public float polarity;
    public Vector3 lastPosition;
    private Rigidbody rb;
    public SphereCollider field;
    private MeshRenderer fieldRenderer;
    [Header("The materials for the magnetic fields")]
    [SerializeField] Material posFieldMat;
    [SerializeField] Material negFieldMat;
    //private Material[] materials;
    private float rightLeftInput;
    private float forwardBackInput;
    private float magInput;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        field = this.GetComponentInChildren<SphereCollider>();
        fieldRenderer = field.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        var currentPosition = transform.position;
        GetMoveInput();
        polarity = magInput;
        lastPosition = currentPosition;
    }
    void FixedUpdate()
    {
        fieldRenderer.enabled = false;
        Move();
    }
    void GetMoveInput()
    {
        rightLeftInput = Input.GetAxis("Horizontal");
        forwardBackInput = Input.GetAxis("BackNForth");
        magInput = Input.GetAxis("Magnet");
    }
    void Move()
    {
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
    }
}
