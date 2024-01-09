using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public float currentHealth;                                   // The current health the player has.
    public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public Slider healthSlider;
    public Image damageImage;
    //public bool hasHitDetecred = false;

    Animator anim;                                              // Reference to the Animator component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    PlayerShooting playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    AudioSource playerAudio;

    [SerializeField] private HeallableObjectType _objectType = HeallableObjectType.Player;


    public Transform ObjectTransform => transform;

    void IHealth.HealAmount(float amount)
    {
        ChangeHp(amount);
    }

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerAudio = GetComponent<AudioSource>();
        // Set the initial health of the player.
        currentHealth = startingHealth;
        healthSlider.value = 100;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AidKit"))
        {
            if (currentHealth + 25 < 100)
            {
                currentHealth += 25;
                other.gameObject.SetActive(false);
                healthSlider.value = currentHealth;
            }

            else if (currentHealth + 25 >= 100)
            {
                currentHealth = 100;
                other.gameObject.SetActive(false);
                healthSlider.value = currentHealth;
            }
        }
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off any remaining shooting effects.
        playerShooting.DisableEffects();

        playerAudio.clip = deathClip;
        playerAudio.Play();

        // Tell the animator that the player is dead.
        anim.SetTrigger("Die");

        // Turn off the movement and shooting scripts.
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    void ChangeHp(float amount)
    {
        currentHealth = currentHealth + amount > startingHealth ? startingHealth : currentHealth + amount;
        healthSlider.value = currentHealth;
    }
    float IHealth.CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    float IHealth.MaxHealth
    {
        get
        {
            return startingHealth;
        }
    }

    public HeallableObjectType ObjectType => HeallableObjectType.Player; 


    Transform IHealth.ObjectTransform => transform;


    void IHealth.TakeDamage(float amount, Vector3 hitPoint)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        ChangeHp(-amount);


        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    bool IHealth.NeedHeal()
    {
        return currentHealth < startingHealth;
    }
}
