using UnityEngine;

//INHERITANCE
public class CircleClickObject : ClickyObject
{
    private Vector2 center;
    private float radius;
    [SerializeField]
    private float minRadius = 1;
    [SerializeField]
    private float maxRadius = 4;
    [SerializeField]
    private float speed = 4;

    public void Awake()
    {
        center = transform.position;
        radius = Random.Range(minRadius, maxRadius);
    }

    protected override void OnClick()
    {
        Destroy(gameObject);
    }

    protected override void Move()
    {
        var progress = Time.time * speed;
        transform.position = center + new Vector2(Mathf.Sin(progress), Mathf.Cos(progress)) * radius;
    }

}
