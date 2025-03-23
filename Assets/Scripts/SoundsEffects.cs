using UnityEngine;

public class SoundsEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public void JumpSfx()
    {
        src.clip = sfx1;
        src.Play();
    }
    
    public void ShieldSfx()
    {
        src.clip = sfx2;
        src.Play();
    }
    
}
