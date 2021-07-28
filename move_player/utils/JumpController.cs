
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Jump {
public class JumpController
  {
    private bool _shouldJump;
    public void handleUpdateJump()
    {
      if (_shouldJump == false)
      {
        _shouldJump = Input.GetKeyDown(KeyCode.Space);
      }
    }
    public void handleFixedUpdateJump(Func<bool> sideEffect)
    {
      if (_shouldJump)
      {
        sideEffect();
        _shouldJump = false;
      }
    }
  }
}
   