class Program{

    //this helped: https://joaoarthurbm.github.io/eda/posts/quick-sort/
    
    static List<int> quickSortList(List<int> list)
    {

        if (list.Count <= 1) {
            return list;
        }

        List<int> smallerSorted = new List<int>();
        List<int> biggerSorted = new List<int>();

        int pivot = list[0];

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] <= pivot) {
                smallerSorted.Add(list[i]);
                //System.Console.WriteLine("movendo "+list[i]+" para a lista de valores menores que "+ pivot);
            }
            else{
                biggerSorted.Add(list[i]);
                //System.Console.WriteLine("movendo "+list[i]+" para a lista de valores maiores que "+ pivot);
            }
        }

        smallerSorted = quickSortList(smallerSorted);
        biggerSorted = quickSortList(biggerSorted);
        
        List<int> result = new List<int>(smallerSorted);
        result.Add(pivot);
        result.AddRange(biggerSorted);

        //retornar e torcer pra n explodir :P
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("digite a lista de numeros para ser organizada");
        string input = Console.ReadLine();

        List<int> originalList = new List<int>();
        foreach (string s in input.Split(' '))
        {
            int number;
            if (int.TryParse(s, out number))
            {
                originalList.Add(number);
            }
        }

        List<int> sortedList = quickSortList(originalList);

        Console.WriteLine("original:\n[" + string.Join(", ", originalList)+"]");
        Console.WriteLine("\norganizada:\n[" + string.Join(", ", sortedList)+"]");
    }
}