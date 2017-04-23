using System.Collections;
using UnityEngine;

interface IMachine {
  IEnumerator idle();
}

class StateMachine {

  public StateMachine() {
  }

  public void run(MonoBehaviour mono, IMachine subject) {
    mono.StartCoroutine(subject.idle());
  }
}
