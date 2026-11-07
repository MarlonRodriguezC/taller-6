using System.Collections;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;

public class WaitToActivate : MonoBehaviour
{
    [Header("PrenderTranslucido")]
    [Tooltip("PrenderApagarObjetosdespuésDeSerSelecciondo")]
    [SerializeField] private GameObject objetoTranslucido;
    [SerializeField] private GameObject tapa1;
    [SerializeField] private GameObject taparInteractuable;
    [SerializeField] private float secondsToWaits;
    [Header("Grab")]
    [SerializeField] private GameObject tapaRotarGrab;
    [SerializeField] private GameObject grabLibro;

    private HandGrabInteractable handInteractable;
    private GrabInteractable grabInteractable;
    private HandGrabInteractable handInteractableRotation;
    private GrabInteractable grabInteractableRotation;

    private void Awake()
    {
        handInteractable = grabLibro.GetComponent<HandGrabInteractable>();
        grabInteractable = grabLibro.GetComponent<GrabInteractable>();
        handInteractableRotation = tapaRotarGrab.GetComponentInChildren<HandGrabInteractable>();
        grabInteractableRotation = tapaRotarGrab.GetComponentInChildren<GrabInteractable>();
    }
    private void Update()
    {
        float rotationX = tapaRotarGrab.transform.localEulerAngles.x;

        if (Mathf.Abs(Mathf.DeltaAngle(rotationX, -90f)) < 2f)
        {
            Debug.Log("¡Llegó a -90 grados!");
            DisaableRotation();
        }
    }
    public void _2daInteraccion()
    {
        StartCoroutine(Prender2daInteraccion(secondsToWaits));
    }
    private void DisaableRotation()
    {
        handInteractableRotation.enabled = false;
        grabInteractableRotation.enabled = false;
    }
    private void DisableGrabHandControll()
    {
        handInteractable.enabled = false;
        grabInteractable.enabled = false;
    }
   IEnumerator Prender2daInteraccion(float seconds) 
    {
        objetoTranslucido.SetActive(false);
        yield return new WaitForSeconds(seconds);
        DisableGrabHandControll();
        tapa1.SetActive(false);
        taparInteractuable.SetActive(true);
        yield return null;
    }
}
