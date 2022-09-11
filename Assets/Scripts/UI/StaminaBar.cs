using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider staminaSlider;

    public float maxStamina = 100;
    private float currentStamina;
    private float regenerateStaminaTime = 0.1f;
    private float regenerateAmount = 2;
    private float losingStaminaTime = 0.1f;

    private Coroutine mycoroutineLosing;

    private Coroutine mycoroutineRegenerate;

    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

    }

    public void UseStamina(float amount)
    {


        if (currentStamina-amount>0)
        {
            if (mycoroutineLosing != null)
            {
                StopCoroutine(mycoroutineLosing);
            }

            mycoroutineLosing = StartCoroutine(LosingStaminaCoroutine(amount));

            if (mycoroutineRegenerate != null)
            {
                StopCoroutine(mycoroutineRegenerate);
            }
            mycoroutineRegenerate = StartCoroutine(RegenerateStaminaCoroutine());
        }

        else
        {
            Debug.Log("No tenemos estamina");
            FindObjectOfType<PlayerMove>().isSprinting = false;

        }
    }

    private IEnumerator LosingStaminaCoroutine(float amount)
    {
        while (currentStamina >= 0)
        {
            currentStamina -= amount;
            staminaSlider.value = currentStamina;
            yield return new WaitForSeconds(losingStaminaTime);

        }

        mycoroutineLosing = null;

        FindObjectOfType<PlayerMove>().isSprinting = false;

    }
    private IEnumerator RegenerateStaminaCoroutine()
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina)
        {
            currentStamina += regenerateAmount;
            staminaSlider.value = currentStamina;

            yield return new WaitForSeconds(regenerateStaminaTime);
        }

        mycoroutineRegenerate = null;

    }

}
