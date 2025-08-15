using UnityEngine;

//INHERITANCE
public class MultiClickObject : ClickyObject
{
    [SerializeField]
    private int life = 5;

    protected override void OnClick()
    {
        life -= 1;
        transform.transform.localScale /= 2;
        Value /= 2;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Move(){}

}
