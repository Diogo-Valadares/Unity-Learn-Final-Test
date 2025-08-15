using UnityEngine;

//INHERITANCE
public class ZigZagClickObject : ClickyObject
{
    private Vector2 direction;
    private float amplitude = 10;
    [SerializeField]
    private float minAmplitude = 80;
    [SerializeField]
    private float maxAmplitude = 160;

    private float speed = 10;
    [SerializeField]
    private float minSpeed = 40;
    [SerializeField] 
    private float maxSpeed = 80;

    private float ZigZagSpeed = 10;
    [SerializeField]
    private float minZigZagSpeed = 5;
    [SerializeField]
    private float maxZigZagSpeed = 10;

    private void Awake()
    {
        direction = Random.insideUnitCircle.normalized;

        amplitude = Random.Range(minAmplitude, maxAmplitude);
        speed = Random.Range(minSpeed, maxSpeed);
        ZigZagSpeed = Random.Range(minZigZagSpeed, maxZigZagSpeed);
    }

    //POLYMORPHISM
    protected override void OnClick()
    {
        Destroy(gameObject);
    }

    //POLYMORPHISM
    protected override void Move()
    {
        transform.position += speed * Time.deltaTime * (Vector3)direction;
        transform.position +=
            Mathf.Sin(Time.time * ZigZagSpeed) * amplitude * Time.deltaTime *
            (Quaternion.Euler(0, 0, 90) * direction);
    }

}
