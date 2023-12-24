int i = 0, j = 0;
while (i<1 || i>30 || j<1 || j>31)
{
    Console.Write("Введите количество строк массива (от 1 до 30): ");
    i = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество элементов в строке массива (от 1 до 30): ");
    j = Convert.ToInt32(Console.ReadLine());

    if (i<1 || i>30 || j<1 || j>31) Console.WriteLine("Неверный ввод!\n");
    else Console.WriteLine();
}

int[,] array = createMassive(i, j); //создали массив с заданным размером
Console.WriteLine("Созданный массив:");
int [] addressMin = new int[2];
addressMin = printMassive(array);//напечатали массив, возвратили адрес мин элемента
Console.WriteLine($"Положение первого найденного минимального \r\nэлемента: '{addressMin[0]},{addressMin[1]}'");
int[,] secondMassive = smollMassive(array, addressMin);//создали уменьшенный массив
Console.WriteLine($"Массив с вырезанными строкой и столбцом, \r\nсодержащим первый найденный минимальный элемент:");
addressMin = printMassive(secondMassive);




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

//---------------------------------Создание массива без строки и столбца с наименьшим элементом
int[,] smollMassive(int[,] array, int[] address)
{
    int[,] smollArray = new int[(array.GetLength(0)-1) , (array.GetLength(1)-1)];
    Console.WriteLine($"Размер нового массива '{smollArray.GetLength(0)},{smollArray.GetLength(1)}'");
    

    for (int i = 0; i < array.GetLength(0); i++)
    {
        if(i < address[0])
        {                
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if(j < address[1] ){smollArray[i,j] = array[i,j];}
                if(j > address[1] ){smollArray[i,j-1] = array[i,j];}
            }  
        }
        if(i > address[0])
        {                
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if(j < address[1] ){smollArray[i-1,j] = array[i,j];}
                if(j > address[1] ){smollArray[i-1,j-1] = array[i,j];}
            }  
        }        
    }
    return smollArray; 
}


//---------------------------------Печать массива, возврат координат минимального элемента
int[] printMassive(int[,] array) 
{    int minimum = 99 * array.GetLength(1);//максимально возможная сумма
     int[] minElement = {0,0};
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write($"[ ");        
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i,j] / 10 == 0) Console.Write($" {array[i,j]} ");
            else Console.Write($"{array[i,j]} ");
            if(minimum > array[i,j])
            {
                minimum = array[i,j];
                minElement[0] = i;
                minElement[1] = j;
            }
        }
        Console.WriteLine($"]");        
    }
    return minElement;
}
