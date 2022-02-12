using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Reference Code is from Brackeys
//https://www.youtube.com/watch?v=BLfNP4Sc_iA
//That is the youtube video
//In Description he said
//All content by Brackeys is 100% free. We believe that education should be available for everyone. Any support is truly appreciated so we can keep on making the content free of charge.

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(int health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
