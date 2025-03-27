using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacheteSlashSound : MonoBehaviour
{
    [SerializeField] private AudioClip macheteSlashSound;
    // Update is called once per frame
    private void Slash()
    {
        var audioSourceMachete = this.gameObject.GetComponent<AudioSource>();
        audioSourceMachete.PlayOneShot(macheteSlashSound);
    }
}
