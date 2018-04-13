using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    public void closePanel()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
