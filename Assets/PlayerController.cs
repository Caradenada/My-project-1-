using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Vector2 movementInput;
    Rigidbody2D rb;

public GameObject objetoContenedor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSorting();
    }

    private void FixedUpdate(){
        if(movementInput != Vector2.zero){
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
                if(count == 0){
                    rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                }
        }
    }
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void updateSorting(){
        {
    float personajePosY = transform.position.y;
    float contenedorPosY = objetoContenedor.transform.position.y;

    Renderer[] renderers = objetoContenedor.GetComponentsInChildren<Renderer>();

    foreach (Renderer renderer in renderers)
    {
        if (personajePosY > contenedorPosY)
        {
            renderer.sortingOrder = 1; // Personaje por encima del objeto contenedor
        }
        else
        {
            renderer.sortingOrder = -1; // Personaje por debajo del objeto contenedor
        }
    }
        }}}
