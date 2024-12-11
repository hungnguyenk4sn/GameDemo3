using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayMove : MonoBehaviour
{
    Rigidbody rb;
    Vector3 Direction;
    [SerializeField] Transform target;
    [Range(1f, 40f)]
    [SerializeField] float speed;
    [Range(1f, 40f)]
    [SerializeField] float _pushStrength = 10f;
    public float PushStrength
    {
        get => _pushStrength;
        set
        {
            if (_pushStrength != value) // Chỉ phát sự kiện nếu giá trị thay đổi
            {
                _pushStrength = value;
               
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Direction = target.transform.position - this.transform.position;
        rb.velocity = Direction.normalized * speed;

    }
    void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Pushable"))

            collision.rigidbody.AddForce(Direction.normalized * _pushStrength, ForceMode.Impulse);


    }
}
