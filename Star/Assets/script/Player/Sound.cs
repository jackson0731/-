using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Sound : MonoBehaviour
{
    public Slider playerSound;
    public Slider warning;
    public float maxSound = 100f;

    public float currentSound;

    public float Soundloss = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        currentSound = 0;
        UpdateSound();
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        GameObject sliderObject = GameObject.Find("Player Sound");
        GameObject sliderObject2 = GameObject.Find("warning");
        
        if (warning == null)
        {
             warning = sliderObject2.GetComponent<Slider>();
        }
        if(playerSound == null)
        {
            playerSound = sliderObject.GetComponent<Slider>();
        }
        if(currentSound < 0)
        {
            currentSound = 0;
        }
        UpdateSound();
    }

    public void minusSound(float amount)
    {
        currentSound -= amount;
        currentSound = Mathf.Clamp(currentSound, 0f, maxSound); // �����q�Ȧb0��̤j�Ȥ���
        
    }

    public void addSound(float amount)
    {
        Soundloss = 3f;
        currentSound += amount;
        currentSound = Mathf.Clamp(currentSound, 0f, maxSound); // �����q�Ȧb0��̤j�Ȥ���
        
    }

    void UpdateSound()
    {
        float fillAmount = currentSound / maxSound; // �p���R�Ȥ��
        warning.value = fillAmount;
        playerSound.value = fillAmount;
    }
}
