using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Deck : MonoBehaviour {

    [SerializeField] private WarCard leftCard;
    [SerializeField] private WarCard rightCard;
    [SerializeField] private Sprite[] warFaces;
    
    [SerializeField] private TextMeshPro scoreLabelLeft;
    [SerializeField] private TextMeshPro scoreLabelRight;

    private int _LScore = 0, _RScore = 0;
    private int card = 0;
    
    private int[] faces = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25};

    public void Start() {
        ShuffleArray(faces);
    }

    public void OnMouseUp() {
        if (card > faces.Length) {
            card = 0;
            ShuffleArray(faces);
        }
        leftCard.SetCard(faces[card], warFaces[faces[card]]);
        rightCard.SetCard(faces[card + 1], warFaces[faces[card]]);
        card += 2;
        Score();
    }

    public void Score() {
        if (leftCard.GetValue() > rightCard.GetValue()) {
            _LScore++;
            scoreLabelLeft.text = "Score: " + _LScore;
            scoreLabelRight.GetComponent<TextMeshPro>().color = Color.white;
            scoreLabelLeft.GetComponent<TextMeshPro>().color = Color.green;
        } else if (leftCard.GetValue() < rightCard.GetValue()) {
            _RScore++;
            scoreLabelRight.text = "Score: " + _RScore;
            scoreLabelLeft.GetComponent<TextMeshPro>().color = Color.white;
            scoreLabelRight.GetComponent<TextMeshPro>().color = Color.green;
        } else {
            scoreLabelLeft.GetComponent<TextMeshPro>().color = Color.yellow;
            scoreLabelRight.GetComponent<TextMeshPro>().color = Color.yellow;
        }
    }

    private void ShuffleArray(int[] faces) {
        for (int i = 0; i < faces.Length; i++) {
            int tmp = faces[i];
            int r = Random.Range(i, faces.Length);
            faces[i] = faces[r];
            faces[r] = tmp;
        }
    }
}
