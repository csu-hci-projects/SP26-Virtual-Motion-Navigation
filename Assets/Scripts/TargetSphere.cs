using UnityEngine;

public class TargetSphere : MonoBehaviour
{
    private Renderer rend;
    private Color originalColor;

    public System.Action onSelected; // callback to manager

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void OnHoverEnter()
    {
        rend.material.color = Color.yellow; // highlight
    }

    public void OnHoverExit()
    {
        rend.material.color = originalColor;
    }

    public void Select()
    {
        onSelected?.Invoke(); // notify manager
    }
}