using UnityEngine;
using System.Collections;

public class WarCard : MonoBehaviour {
    private int _value;

    public void SetCard(int value, Sprite image) {
        _value = value % 13;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public int GetValue() {
        return _value;
    }
}
