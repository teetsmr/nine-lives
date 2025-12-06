using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    [SerializeField] private Animator anim;
    private bool dead;

    AudioManager audioManager;
    [SerializeField] private AudioClip hurtClip;
    [SerializeField] private AudioClip dieClip;

    private void Awake()
    {
        currentHealth = startingHealth;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            AudioManager.Instance?.PlaySFX(hurtClip);

        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<Player>().enabled = false;
                dead = true;
                AudioManager.Instance?.PlaySFX(dieClip);
            }

        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(startingHealth, currentHealth + amount);
        // update UI if needed
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
