using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public static bool playerDead = false;
    [SerializeField] protected AudioSource immune = default;

    public UnityEvent PlayerDead;

    protected override void Start()
    {
        UpdateMaxStat();
        playerDead = false;
    }
    public override float CurrrentStat
    {
        get
        {
            return currentStat;
        }
        set
        {
            if (value - currentStat < 0)
            {
                currentStat = value;
                PlayHitSound();
            }
            else
            {
                currentStat = value;
            }
            if (currentStat <= 0)
            {
                Death();
                return;
            }
            else if (currentStat > maxStat)
            {
                currentStat = maxStat;
            }

            if (statBar != null)
            {
                statBar.SetValue(currentStat);
            }
        }
    }
    protected override void Death()
    {
        playerDead = true;
        PlayerDead.Invoke();
    }

}
