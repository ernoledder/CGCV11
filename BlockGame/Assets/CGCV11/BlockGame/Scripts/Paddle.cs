using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CGCV11.BlockGame.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Paddle : MonoBehaviour
    {
        private Rigidbody _rigidBody;
        [SerializeField] private float left, right, speed;
        private Vector3 playerPos = new Vector3(0, 0.5f, 0);

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.isKinematic = true;
        }

        private void Reset()
        {
            left = -3;
            right = 3;
            speed = 12;
        }

        private void Update()
        {
            float step = speed * Time.deltaTime;
            float xPos = transform.position.x + (Input.GetAxis("Horizontal") * step);
            playerPos = new Vector3(Mathf.Clamp(xPos, -3, 3), 0.5f, 0);
            transform.position = playerPos;
        }
    }
}

