using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public UnityEvent PlayerDead;

    protected override void Death()
    {
        PlayerDead.Invoke();
        GetComponent<AudioManager>().Play("Death");
    }

}
