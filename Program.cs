using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); // 创建随机数生成器
        int correctCount = 0; // 用于跟踪回答正确的题目数量
        int consecutiveWrongCount = 0; // 用于跟踪连续回答错误的题目数量

        while (true)
        {
            int num1 = random.Next(1, 11); // 生成第一个随机数
            int num2 = random.Next(1, 11); // 生成第二个随机数
            char operatorChar = random.Next(2) == 0 ? '+' : '-'; // 随机选择加法或减法运算符

            Console.Write($"{num1} {operatorChar} {num2} = ?"); // 显示题目
            int userAnswer;

            if (int.TryParse(Console.ReadLine(), out userAnswer)) // 获取用户输入并尝试解析为整数
            {
                int correctAnswer = operatorChar == '+' ? num1 + num2 : num1 - num2; // 计算正确答案

                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("回答正确！");
                    correctCount++; // 回答正确，增加正确计数
                    consecutiveWrongCount = 0; // 重置连续错误计数
                }
                else
                {
                    Console.WriteLine("回答错误，请重新回答。");
                    consecutiveWrongCount++; // 回答错误，增加连续错误计数

                    if (consecutiveWrongCount >= 3)
                    {
                        Console.WriteLine($"本题练习结束，正确答案是 {correctAnswer}");
                        consecutiveWrongCount = 0; // 连续回答错误3次，显示正确答案并重置计数
                    }
                }

                Console.Write("是否继续练习？(Y/N): ");
                string continueResponse = Console.ReadLine(); // 获取用户是否继续练习的响应

                if (continueResponse.ToUpper() != "Y") // 如果不继续，退出循环
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("请输入有效的数字答案。"); // 用户输入无效，提示重新输入
            }
        }

        Console.WriteLine($"你一共回答了 {correctCount} 题正确。"); // 显示总的正确回答数量
    }
}
