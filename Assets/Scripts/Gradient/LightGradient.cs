using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightGradient : MySimpleGradient
{
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();

        StartCoroutine(OnGradient());
    }

    IEnumerator OnGradient()
    {
        for (float i = 0; i < 1; i += Speed * Time.deltaTime)
        {
            _light.color = Gradient.Evaluate(i);
            yield return new WaitForSeconds(0.1f);
        }

        for (float i = 1; i > 0; i -= Speed * Time.deltaTime)
        {
            _light.color = Gradient.Evaluate(i);
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(OnGradient());
    }
}
