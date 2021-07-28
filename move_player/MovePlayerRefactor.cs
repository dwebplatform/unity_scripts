using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JumpAble {
  private bool _shouldJump;

  private void handleJumpFixed() {
    if (_shouldJump == false) {
      _shouldJump = Input.GetKeyDown(KeyCode.Space);
    }
  }

  private void handleJump(Rigidbody rb) {
    if (_shouldJump) {
      //TODO:
      rb.AddForce(Vector3.up * 10 f);
      _shouldJump = false;
    }

  }
  public class MovePlayer: MonoBehaviour {

    private Rigidbody _playerRb;
    [SerializeField]
    private float _speed = 12 f;
    [SerializeField]
    private float _jumpForce = 15 f;
    private void Awake() => _playerRb = GetComponent<Rigidbody>();
    private bool _shouldJump = false;

    private void handleMove() {
      Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
      Vector3 normilizedSpeed = dir.normalized * _speed * Time.deltaTime;
      _playerRb.MovePosition(transform.position + normilizedSpeed);
    }
    private void handleJumpFixed() {
      if (_shouldJump == false) {
        _shouldJump = Input.GetKeyDown(KeyCode.Space);
      }
    }

    private void handleJump() {
      if (_shouldJump) {
        _playerRb.AddForce(Vector3.up * _jumpForce);
        _shouldJump = false;
      }
    }

    private void FixedUpdate() {
      handleMove();
      handleJumpFixed();
    }
    void Update() {
      handleJump();
    }

  }
