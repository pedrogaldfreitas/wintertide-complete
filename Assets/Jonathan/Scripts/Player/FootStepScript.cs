using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FootStepScript : MonoBehaviour
{
    [SerializeField] private AudioClip [] footstepSounds;//List Of Footsteps
    private float height; //height of Raycast
    private AudioSource playerAudioSource;
    private RaycastHit hit;

    private void Awake()
    {
        playerAudioSource = this.gameObject.GetComponent<AudioSource>();
        height = this.gameObject.GetComponentInParent<CapsuleCollider>().height; //Returns Height of Player
    }

    private void Step()
    {
        string terrainName = CheckGround();
        if (terrainName == "N/A") return;
        AudioClip getClip = footstepSounds[4];

        switch (terrainName)
        {
            case "Snow":
                getClip = footstepSounds[0];
                PlayAudio(getClip);
                break;
            case "Concrete":
                getClip = footstepSounds[1];
                PlayAudio(getClip);

                break;
            case "Indoor":
                getClip = footstepSounds[2];
                PlayAudio(getClip);

                break;
            case "Dirt":
                getClip = footstepSounds[3];
                PlayAudio(getClip);

                break;

        }



    }

    private string CheckGround()
    {
        Transform footStep = this.gameObject.GetComponent<Transform>();
        float reachRange = (height / 2f) + 0.5f;
        //Debug.DrawRay(footStep.position, footStep.up * -1f * reachRange, Color.green);

        if (!Physics.Raycast(footStep.position, footStep.up * -1f, out hit, reachRange)) return "N/A";

        
        switch (hit.collider.tag)
        {
            case "SnowGround":
                return "Snow";

            case "DirtGround":
                return "Dirt";

            case "IndoorGround":
                return "Indoor";

            case "ConcreteGround":
                return "Concrete";

        }

        return "N/A";
    }

    private void PlayAudio(AudioClip footstep)
    {

        playerAudioSource.pitch = Random.Range(0.6f, 1.0f);
        playerAudioSource.volume = Random.Range(0.1f, 0.2f);

        playerAudioSource.PlayOneShot(footstep);
    }
}
