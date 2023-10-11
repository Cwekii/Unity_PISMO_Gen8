using System.Collections.Generic;

public class BasicClass
{
    private int first = 1;
    private int second = 2;
    private int sum;
    private List<int> intList = new List<int>(3){2, 4, 8};

    // Zamislite da pozivamo CalculateSum(first, second)
    private void CalculateSum(int x, int y)
    {
        x = 5; // first je i dalje 1!
        sum = x + y;
    }

    private void ChangeGunRange(Gun gun, float newRange)
    {
        gun.ChangeRange(newRange);
    }

    // Zamislite da pozivamo ChangeSecondValue(intList)
    private void ChangeSecondValue(List<int> list)
    {
        list[1] = 5;
    }

    private void CreateRandomString()
    {
        string tempString = "abc";
        char firstChar = tempString[0]; // 'a'
    }
}
