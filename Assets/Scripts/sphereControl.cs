using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sphereControl : MonoBehaviour {

    public Text countText;
    public Text winText;
    private Rigidbody spherePhy;
    private float xForce;
    private float zForce;

    private bool isFalling;
    private float previousY;
    private float currentY;

    public float jumpSpeed;
    public float forceSpeed;
    private Vector3 forceDirection;
    private Vector3 jumpForce;

    AudioSource miAudio;
    public AudioClip sonidoPickup;
    public AudioClip sonidoGanar;

    private GameObject[] pickups;

    private int counter;

    // Start is called before the first frame update
    void Start () {
        counter = 0;
        pickups = GameObject.FindGameObjectsWithTag ("Pick Up");
        SetCount ();
        winText.text = "";
        previousY = 0.5f;
        currentY = 0.5f;

        spherePhy = GetComponent<Rigidbody> ();

        miAudio = GameObject.Find ("Audio Source").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate () {

        //////Inputs de Fuerzas//////

        //inputs de movimiento horizontal

        xForce = Input.GetAxis ("Horizontal");
        zForce = Input.GetAxis ("Vertical");

        forceDirection = new Vector3 (xForce, 0, zForce);

        //input de salto

        if (Input.GetKeyDown ("space") == true) {

            jumpForce = new Vector3 (0, jumpSpeed * 100, 0);
        } else {

            jumpForce = new Vector3 (0, 0, 0);
        }

        //Evalua si la bola está en el aire o está en el suelo

        currentY = transform.position.y;

        if (currentY == previousY) {
            isFalling = false;
        } else {
            isFalling = true;
        }

        ///////////Aplica las fuerzas a la esfera////////////////////

        //fuerza horizontal
        spherePhy.AddForce (forceDirection * forceSpeed);

        //agrega el salto solo si no está en el aire
        if (isFalling == false) {
            //fuerza del salto
            spherePhy.AddForce (jumpForce);

        }

        //la posicion actual pasa a ser antigua
        previousY = currentY;

    } //cierra el metodo fixedUptdate

    void OnTriggerEnter (Collider pickup) {
        if (pickup.gameObject.CompareTag ("Pick Up")) {
            pickup.gameObject.SetActive (false);
            counter += 1;
            SetCount ();
            miAudio.PlayOneShot(sonidoPickup);
        }

    } //metodo OnTrigger

    void SetCount () {
        countText.text = "Count: " + counter.ToString ();

        if (counter >= 14) {
            winText.text = "YOU WIN";
            miAudio.PlayOneShot(sonidoGanar);
        }
    } //metodo SetCount

} //cierra el script spherecontrol