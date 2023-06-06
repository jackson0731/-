using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sound : MonoBehaviour
{
    public Slider slider;
    public float maxSound = 100f;

    private float currentSound;

    private float Soundloss = 3f;

    // Start is called before the first frame update
    void Start()
    {
        currentSound = 0;
        UpdateSound();
    }

    void Update()
    {
        
        if (currentSound != 100)
        {
            if (Soundloss <= 0)
            {
                currentSound -= 5f;
                UpdateSound();
                Soundloss = 3f;
            }
            else
            {
                Soundloss -= Time.deltaTime;
            }
        }
    }

    public void minusSound(float amount)
    {
        currentSound -= amount;
        currentSound = Mathf.Clamp(currentSound, 0f, maxSound); // �����q�Ȧb0��̤j�Ȥ���
        UpdateSound();
    }

    public void addSound(float amount)
    {
        Soundloss = 3f;
        currentSound += amount;
        currentSound = Mathf.Clamp(currentSound, 0f, maxSound); // �����q�Ȧb0��̤j�Ȥ���
        UpdateSound();
    }

    private void UpdateSound()
    {
        float fillAmount = currentSound / maxSound; // �p���R�Ȥ��
        slider.value = fillAmount;
    }
}
