using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CGCV11.BlockGame.Scripts
{
    [RequireComponent(typeof(Rigidbody))]

    public class Ball : MonoBehaviour
    {
        public GameManager gamemanager;
        private Rigidbody _rigidBody;
        [SerializeField] private float speed;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.isKinematic = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Water")
            {
                gamemanager.CollideWater(other);
            }
            if (other.gameObject.tag == "Brick")
            {
                gamemanager.CollideBrick(other);
            }
        }

        public void Reset()
        {
            speed = 0;
        }

        private void Start()
        {
            _rigidBody.AddForce(new Vector3(0.001f, -speed, 0), ForceMode.Impulse);
        }
    }
}

