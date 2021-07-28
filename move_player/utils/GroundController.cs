
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ground {
public class GroundController
  {
    private Transform _transformPosition;
    public GroundController(Transform transform){
            _transformPosition = transform;
    }
    private bool _grounded;
    public bool isGrounded()
    {
      return _grounded;
    }
    public void checkGrounded()
    {
      RaycastHit hit;
      //TODO: получать размер коробки из методов а не 6f
      if (Physics.Raycast(_transformPosition.position, -Vector3.up, out hit, 1f))
      {
        _grounded = true;
      }
      else
      {
        _grounded = false;
      }
    }

  }
}
   