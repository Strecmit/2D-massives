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

printMassive(array);

Console.Write("Введите номер столбца элемента в массиве: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите номер строки элемента в массиве: ");
int m = Convert.ToInt32(Console.ReadLine());

myElement(array, m,n);

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

//---------------------------------------вывод элемента по координатам
int myElement(int[,] array, int m, int n)
{
    if (m < array.GetLength(0) && n < array.GetLength(1))
    {

        Console.WriteLine($"\r\nЗначение заданного элемента {array[m,n]}.");
    }
    else
    {
        Console.WriteLine("Координаты элемента неверны!");
        return 0;
    }
    return array[m,n];
}