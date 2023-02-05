using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZonaDefender : MonoBehaviour
{
    public int defensaIncial = 10;
    [SerializeField]
    int defensaRestante = 10;
    public TextMeshProUGUI text;
    public Slider slider;
    public AudioClip damageSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        defensaRestante = defensaIncial;   
    }

    // Update is called once per frame
    void Update()
    {
        text.text = defensaRestante.ToString();
        slider.value = RatioDefensa();
        CheckDefeat();
    }

    public float RatioDefensa()
    {
        return defensaRestante / (float)defensaIncial;
    }

    public void ReducirDefensa(int cantidadReducida)
    {
        if (!Temporizador.victory) {
            defensaRestante -= cantidadReducida;
            GetComponent<AudioSource>().clip = damageSoundEffect;
            GetComponent<AudioSource>().Play();
        }
    }

    void CheckDefeat()
    {
        if (defensaRestante <= 0)
        {
            PlayerPrefs.SetString("Outcome", "Defeat");
            SceneManager.LoadScene(2);
        }
    }
}
