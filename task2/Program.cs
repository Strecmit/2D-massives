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
Console.WriteLine("Созданный массив:");
printMassive(array);
Console.WriteLine("Новый массив:");
changeElements(array);
printMassive(array);



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
//-------------------------------------Вывод массива
void printMassive(int[,] array)
{    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
           if(array[i,j] / 10 == 0) Console.Write($" {array[i,j]} ");
           else Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine("]");
    }
    Console.WriteLine();
    return;
}

//---------------------------------------перемена первой и последней строки
int[,] changeElements(int[,] array)
{
    int temp = 0, i = array.GetLength(0) - 1;
    for (int j = 0; j < array.GetLength(1); j++)
    {
        temp = array[i,j];
        array[i,j] = array[0,j];
        array[0,j] = temp;
    }

    return array;
}