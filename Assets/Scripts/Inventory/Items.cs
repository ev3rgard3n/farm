
[System.Serializable]
public class Item
{
    public static int TYPEFOOD = 1;
    public static int TYPEHOE = 2;
    public static int TYPEAXE = 3;

    public string name;
    public string imageUrl;
    public int type;
    public int count;
    public int price;
    public int lvlWhenUnlock;
    public float timeToGrow;

    public Item(string name, string imageUrl, int type, int count, int price, int lvlWhenUnlock, float timeToGrow)
    {
        this.name = name;
        this.imageUrl = imageUrl;
        this.type = type;
        this.count = count;
        this.price = price;
        this.lvlWhenUnlock = lvlWhenUnlock;
        this.timeToGrow = timeToGrow;
    }
}