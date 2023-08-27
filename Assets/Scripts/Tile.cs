using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TileState state { get; private set; }
    public TileCell cell { get; private set; }
    public int number { get; private set; }
    public float animationDuration = 0.1f;

    private Image background;
    private TextMeshProUGUI text;

    private void Awake()
    {
        background = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetState(TileState state, int number)
    {
        this.state = state;
        this.number = number;

        background.color = state.backgroundColor;
        text.color = state.textColor;
        text.text = number.ToString();
    }

    public void Spawn(TileCell cell)
    {
        if (this.cell != null) {
            this.cell.tile = null;
            Debug.Log("This shouldn't happen!");
        }

        this.cell = cell;
        this.cell.tile = this;

        transform.position = cell.transform.position;
    }

    public void MoveTo(TileCell cell)
    {
        if (this.cell != null) {
            this.cell.tile = null;
            Debug.Log("This shouldn't happen!");
        }

        this.cell = cell;
        this.cell.tile = this;

        StartCoroutine(Animate(cell.transform.position));
    }

    private IEnumerator Animate(Vector3 to)
    {
        float elapsed = 0f;
        var from = transform.position;

        while (elapsed < animationDuration)
        {
            transform.position = Vector3.Lerp(from, to, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = to;
    }
}
