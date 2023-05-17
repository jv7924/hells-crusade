using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTracker : MonoBehaviour
{
    void OnDestroy(){
        FloorManager.Instance.OnEnemyDeath.Invoke();
    }
}
