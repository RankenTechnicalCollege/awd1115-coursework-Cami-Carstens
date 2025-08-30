int sum = 0;
int min = int.MaxValue;
int max = int.MinValue;



int[] testScores = [100, 90,30, 88, 75, 93,95, 70, 65, 58];


for (int i = 0; i < testScores.Length; i++)
{
    int score = testScores[i];
    sum += score;

    if (score < min)
    {
        min = score;
    }
    if (score > max)
    {
        max = score;
    }
}

double average = (double)sum / testScores.Length;
Console.WriteLine($" Sum of scores: {sum}\n Your Worst Score: {min}\n Your Best Score: {max}\n Average Score: {average:f2}");