using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    public Transform Player {  get; set; }
    public Health EnemyHP { get; }
    public void updateState();
    public void moveTo(Vector3 point);
    public void rotateTo(Vector3 point);
    public void attack(bool state);
    public void death();
    public void stunBegin();
    public void stunEnd();
    public void stop(bool state);
    public void positionAndRotation(Vector3 spawnPosition, Quaternion spawnRotation);
}
