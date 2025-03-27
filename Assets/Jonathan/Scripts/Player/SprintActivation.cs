using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprintActivation : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("parkingLot")) return;
        this.gameObject.GetComponentInParent<playerMovement>().canSprint = true;
    }
}
