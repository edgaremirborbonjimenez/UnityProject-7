using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float speed,speedRotation;
    private float horizontalInput, verticalInput;
    public bool usePishics;

    public float limite;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    movePlayer();
    mantenerJugadorDentroDeZona();



    }

    private void movePlayer()
    {
        //Dos tipos de traslados y rotaciones existentes
        if (usePishics)
        {
                    //Version del curso
          //  _rigidbody.AddTorque(Vector3.forward*Time.deltaTime*speed*verticalInput,ForceMode.Force);
            //Para la rotacion con fuerza
          //  _rigidbody.AddTorque(Vector3.up*Time.deltaTime*speedRotation*horizontalInput,ForceMode.Force);
          
          //Version con rotacion descubierta por emir :)
          _rigidbody.AddTorque(Vector3.right*Time.deltaTime*speed*verticalInput,ForceMode.Force);
          _rigidbody.AddTorque(Vector3.back*Time.deltaTime*speedRotation*horizontalInput,ForceMode.Force);
        }
        else
        {
            
            transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
            transform.Rotate(Vector3.up*Time.deltaTime*speedRotation*horizontalInput);
        }
    }

    private void mantenerJugadorDentroDeZona()
    {
        //Para evitar que se salga de los limites
        if (Mathf.Abs(transform.position.x)>=limite || Mathf.Abs(transform.position.z)>=limite)
        {

            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > limite)
            {
                transform.position = new Vector3(limite, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -limite)
            {
                transform.position = new Vector3(-limite, transform.position.y, transform.position.z);
            }
            if (transform.position.z > limite)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, limite);
            }

            if (transform.position.z < -limite)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -limite);
            }

        }
    }
}
