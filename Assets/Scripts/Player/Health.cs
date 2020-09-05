
using UnityEngine;


public class Health : Stat
{
    [SerializeField] protected GameObject deathEffect = default;
    [SerializeField] protected AudioSource hitSound = default;
    [SerializeField] public bool isDead = false;
     
    public override float CurrrentStat
    {
        get
        {
            return currentStat;
        }
        set
        {
            if (value - currentStat  < 0)
            {
                PlayHitSound();
            }
            currentStat = value;
            if (currentStat <= 0 && isDead == false)
            {
                Death();
                isDead = true;
                return;
            }
            else if (currentStat > maxStat)
            {
                currentStat = maxStat;
            }
            isDead = false;
        }
    }
    public virtual void Revive()
    {
        UpdateMaxStat();
    }

    protected virtual void Death()
    {
        GameObject go = Instantiate(deathEffect, this.transform.position, Quaternion.identity);
        Destroy(go, 2);
        Destroy(this.gameObject);
    }

    public void PlayHitSound()
    {
        if (hitSound == null)
            return;
        if (!hitSound.isPlaying && hitSound.enabled)
            hitSound.Play();
    }

    
}
