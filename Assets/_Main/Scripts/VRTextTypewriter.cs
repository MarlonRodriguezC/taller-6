using UnityEngine;
using System.Collections;
using TMPro;

public class VRTextTypewriter : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    [Tooltip("Tiempo de retraso entre cada letra (más alto = más lento y suave)")]
    public float timePerCharacter = 0.03f;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        StartCoroutine(ShowTextSmoothly());
    }

    IEnumerator ShowTextSmoothly()
    {
        // Asegurarnos de que arranca invisible
        textMeshPro.maxVisibleCharacters = 0;
        int totalCharacters = textMeshPro.text.Length;

        // Pequeña pausa inicial para que el usuario enfoque la mirada
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i <= totalCharacters; i++)
        {
            textMeshPro.maxVisibleCharacters = i;
            yield return new WaitForSeconds(timePerCharacter);
        }
    }
}