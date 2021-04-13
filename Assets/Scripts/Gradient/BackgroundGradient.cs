using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class BackgroundGradient : MySimpleGradient
{
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();

        StartCoroutine(OnGradient());
    }

    IEnumerator OnGradient()
    {
        for (float i = 0; i < 1; i += Speed * Time.deltaTime)
        {
            _camera.backgroundColor = Gradient.Evaluate(i);
            yield return new WaitForSeconds(0.1f);
        }

        for (float i = 1; i > 0; i -= Speed * Time.deltaTime)
        {
            _camera.backgroundColor = Gradient.Evaluate(i);
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(OnGradient());
    }
}
