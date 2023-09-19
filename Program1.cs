using System;

class Program1
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int correctCount = 0;
        int incorrectCount = 0;
        string[] incorrectQuestions = new string[10]; // 使用字符串数组，最多存储10个错误的问题

        Console.WriteLine("欢迎使用一年级数学教学辅助系统！");
        Console.WriteLine("你将连续回答10道题目，不给机会重做。");

        for (int i = 1; i <= 10; i++)
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
            char operatorChar = random.Next(2) == 0 ? '+' : '-';
            int correctAnswer = operatorChar == '+' ? num1 + num2 : num1 - num2;

            Console.Write($"{i}. {num1} {operatorChar} {num2} = ?");
            int userAnswer;

            if (int.TryParse(Console.ReadLine(), out userAnswer))
            {
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("回答正确！");
                    correctCount++;
                }
                else
                {
                    Console.WriteLine($"回答错误，正确答案是 {correctAnswer}。");
                    incorrectCount++;

                    // 将错误问题存储在数组中
                    incorrectQuestions[incorrectCount - 1] = $"{num1} {operatorChar} {num2} = ? (正确答案: {correctAnswer})";
                }
            }
            else
            {
                Console.WriteLine("请输入有效的数字答案。");
            }
        }

        Console.WriteLine("全部完成！");

        if (incorrectCount > 0)
        {
            Console.WriteLine($"你一共回答了 {correctCount} 题正确。");
            Console.WriteLine($"你回答了 {incorrectCount} 题错误，以下是错误题目：");

            for (int i = 0; i < incorrectCount; i++)
            {
                Console.WriteLine(incorrectQuestions[i]); // 显示错误问题
            }
        }
        else
        {
            Console.WriteLine($"你一共回答了 {correctCount} 题正确，全对！");
        }
    }
}
