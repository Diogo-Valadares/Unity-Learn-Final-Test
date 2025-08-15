using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

//ABSTRACTION
public abstract class ClickyObject : MonoBehaviour, IPointerClickHandler
{
    //ENCAPSULATION
    [SerializeField]
    private int value = 100;
    public int Value {
        get => value; 
        set { this.value = value; valueText.text = value.ToString(); } 
    }

    [SerializeField]
    private TextMeshPro valueText;

    private void Start()
    {
        Value = value;
    }
    private void Update()
    {
        Move();
        WrapMovement();
    }
    private void OnDestroy()
    {
        GameManager.spawnedCount--;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.AddPoints(value);
        OnClick();
    }

    private void WrapMovement()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        if (position.x > 1f) position.x = 0f;
        else if (position.x < 0f) position.x = 1f;

        if (position.y > 1f) position.y = 0f;
        else if (position.y < 0f) position.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    //ABSTRACTION
    protected abstract void Move();
    protected abstract void OnClick();
}
