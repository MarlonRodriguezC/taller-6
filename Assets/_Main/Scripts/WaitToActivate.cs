using System.Collections;
using UnityEngine;

public class WaitToActivate : MonoBehaviour
{
    [Header("PrenderTranslucido")]
    [Tooltip("PrenderApagarObjetosdespuésDeSerSelecciondo")]
    [SerializeField] private GameObject objetoTranslucido;
    [SerializeField] private GameObject tapa1;
    [SerializeField] private GameObject taparInteractuable;
    [SerializeField] private float secondsToWaits;
    private void Awake()
    {
        
    }
    public void _2daInteraccion()
    {
        StartCoroutine(Prender2daInteraccion(secondsToWaits));
    }
   IEnumerator Prender2daInteraccion(float seconds) 
    {
        objetoTranslucido.SetActive(false);
        yield return new WaitForSeconds(seconds);
        tapa1.SetActive(false);
        taparInteractuable.SetActive(true);
        yield return null;
    }
}
