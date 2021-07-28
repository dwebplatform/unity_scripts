using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jump;
public class MovePlayerAnotherWay : MonoBehaviour
{
  private Rigidbody _playerBody;
  private JumpController _jumpController = new JumpController();
  [SerializeField] private float _jumpForce = 300f;
  [SerializeField] private float _speed = 10f;
  private void Awake() { 
    _playerBody = GetComponent<Rigidbody>();
   }
  private void handleMove()
  {
    Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    Vector3 normilizedSpeed = dir.normalized * _speed * Time.deltaTime;
    _playerBody.MovePosition(transform.position + normilizedSpeed);
  }
  private void makeJump()
  {
    _playerBody.AddForce(_jumpForce * Vector3.up);
  }
  void Update()
  {
    _jumpController.handleUpdateJump();
    handleMove();
  }


  
  void FixedUpdate()
  {
    _jumpController.handleFixedUpdateJump(() =>
    {
      makeJump();
      return true;
    });
  }
}