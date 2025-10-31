namespace Linked_lists;

class Program
{
    static void Main(string[] args)
    {
        MyLinkedList<int> list = new();

        int[] toAdd = [1, 6, 7, 3, 4];
        
        foreach (int number in toAdd)
        {
            list.Append(number);
        }

        list.Insert(1000, 3);
        int runs = 0;
        foreach (int num in list)
        {
            Console.WriteLine(num);
            runs++;
        }
    }
}
