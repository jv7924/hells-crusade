using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTracker : MonoBehaviour
{
    void OnDestroy(){
        Debug.Log("Enemy Killed");
        FloorManager.Instance.OnEnemyDeath.Invoke();
    }
}
