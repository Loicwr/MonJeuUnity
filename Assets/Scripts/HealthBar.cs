using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    // sert a initialiser la barre de vie
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Sert a indiquer le nombre de point de vie a afficher ( dégat ou soins )
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
