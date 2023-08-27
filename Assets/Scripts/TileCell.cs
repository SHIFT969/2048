using UnityEngine;

public class TileCell : MonoBehaviour
{
    public Vector2Int coordinates { get; set; }

    public Tile tile { get; private set; }

    public bool empty => tile == null;

    public bool occupied => tile != null;
}
