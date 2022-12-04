using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Scripts.Managers;

namespace _Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        #region Singleton

        public static PlayerMovement instance;

        #endregion
        
        #region Public Variables
        [Header("Statistics")]
        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float rotSmoothTime = 15.0f;
        [SerializeField] private float jumpHeight = 1.0f;

        [Header("General Game things")] 
        [SerializeField] private GameManager gameManger;
        #endregion
        
        #region Private Variables
        private CharacterController _controller;
        private Camera _camera;
        private Vector3 _playerVelocity;
        private float _currentAngle;
        #endregion

        void Awake()
        {
            instance = this;
            _controller = GetComponent<CharacterController>();
            _camera = Camera.main;
        }
        
        void FixedUpdate()
        {
            Move(_controller);
        }

        private void Move(CharacterController player)
        {
            // Jump Code
            if (player.isGrounded && _playerVelocity.y < 0)
                _playerVelocity.y = gameManger.groundedGravity;

            if (player.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _playerVelocity.y = Mathf.Sqrt(jumpHeight * 2f * gameManger.gravity);
            }

            _playerVelocity.y -= gameManger.gravity * Time.deltaTime;
            player.Move(Vector3.up * _playerVelocity.y * Time.deltaTime);
            
            
            // Movement code
            Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            
            if (movement.magnitude >= 0.1)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
                _currentAngle = Mathf.SmoothDampAngle(_currentAngle, targetAngle, ref _currentAngle, rotSmoothTime);
                
                player.Move(movement * playerSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, _currentAngle, 0);
            }
        }
    }
}