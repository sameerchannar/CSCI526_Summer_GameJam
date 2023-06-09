using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinMessageDisplay : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.enabled = false;
        Debug.Log("hiding");
    }

    // Update is called once per frame
    void Update()
    {
        if (global.win) {
            textComponent.enabled = true;
        }
    }
}
