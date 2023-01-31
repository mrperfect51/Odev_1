using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chracterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        

    }

    private void FixedUpdate()
    {
       
       //r2d.velocity = new Vector2(speed, 0f);
    }
    void Update() // her frame �al���yor
    {

        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos; // hesapladigim pozisyon karakterime esit
        
        if (Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", 1.0f);
        }
        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        } 
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
       
  
    }
    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
    }

}      
