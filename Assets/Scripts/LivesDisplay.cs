using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hello");
        textComponent.text = "Lives: " + global.lives.ToString();
    }
}
