using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextVisibility : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject rightinfoTextObject;
    public GameObject leftinfoTextObject;

    public void Start()
    {
        // Başlangıçta infoText'i gizle
        rightinfoTextObject.SetActive(false);
        leftinfoTextObject.SetActive(false);

        // Butondan Selectable bileşenini kaldır
        var button = GetComponent<Button>();
        if (button != null)
        {
            Destroy(button);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Fare butonun üzerine gelince
        rightinfoTextObject.SetActive(true);
        leftinfoTextObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Fare butondan ayrılınca
        rightinfoTextObject.SetActive(false);
        leftinfoTextObject.SetActive(false);            //True yapınca güzel bir arayüz olabilir
    }
}
