//INHERITANCE
public class RegularObject : ClickyObject
{
    protected override void OnClick()
    {
        Destroy(gameObject);
    }

    protected override void Move() { }

}