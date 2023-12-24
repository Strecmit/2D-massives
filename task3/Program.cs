int i = 0, j = 0;
while (i<1 || i>30 || j<1 || j>31)
{
    Console.Write("Введите количество элементов в строке массива (от 1 до 30): ");
    j = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество строк массива (от 1 до 30): ");
    i = Convert.ToInt32(Console.ReadLine());
    if (i<1 || i>30 || j<1 || j>31) Console.WriteLine("Неверный ввод!\n");
    else Console.WriteLine();
}

int[,] array = createMassive(i, j);
Console.WriteLine("Созданный массив c суммой элементов по строкам:");
int minStr = printMassive(array);
Console.WriteLine($"Номер строки с минимальной суммой элементов {minStr}.");




//-------------------------------------Создание массива
int[,] createMassive(int str, int col)
{
    int[,] array = new int[str, col];
    for (int i = 0; i < str; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i,j] = new Random().Next(1,100);
        }
    }
    return array;
}
//-------------------------------------Вывод массива с минимальной суммой элементов строки и 
int printMassive(int[,] array) //      возврат номера строки с минимальной суммой элементов
{    int sum =0, sumMin = 99*array.GetLength(1), minStr = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (i<10){Console.Write($" {i} [ ");}
        else{Console.Write($"{i} [ ");}        
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i,j];
            if(array[i,j] / 10 == 0) Console.Write($" {array[i,j]} ");
            else Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine($"] = {sum}");
        if (sumMin > sum)
        {
             sumMin = sum;
             minStr = i;
        }
        sum = 0;
    }
    Console.WriteLine();
    return minStr;
}
