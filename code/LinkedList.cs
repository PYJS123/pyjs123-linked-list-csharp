namespace Linked_lists;

#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8603

public class Node<T>(T? value)
{
    public T? value = value;
    public Node<T>? next;
}

public class MyLinkedList<T>
{
    public int length = 0;
    public Node<T>? head;
    public Node<T>? tail;
    Exception OutOfBoundsException = new Exception("Index out of bounds!");
    Node<T>? current=new Node<T>(default);

    public bool IsEmpty() {
        return length == 0;
    }

    public void Append(T item)
    {
        if (length == 0)
        {
            head = new Node<T>(item);
            tail = head;
        }
        else if (tail is not null)
        {
            tail.next = new Node<T>(item);
            tail = tail.next;
        }
        length++;
    }

    public void Insert(T item, int index)
    {
        if (index > length) throw OutOfBoundsException;
        if (index == length)
        {
            Append(item);
        }
        else if (index == 0)
        {
            Node<T> temp = head;
            head = new Node<T>(item);
            head.next = temp;
        }
        else
        {
            int currIndex = 0;
            Node<T> currItem = head;
            Node<T>? prevItem = new Node<T>(default);
            while (currIndex < index)
            {
                currIndex++;
                prevItem = currItem;
                currItem = currItem.next;
            }
            Node<T> newItem = prevItem.next = new Node<T>(item);
            newItem.next = currItem;
        }
        length++;
    }

    public T Access(int index)
    {
        if (IsEmpty()) throw new Exception("List is empty!");
        if (index >= length) throw OutOfBoundsException;
        int currIndex = 0;
        Node<T>? currItem = (head is not null) ? head: new Node<T>(default);
        T? toReturn = currItem.value;
        while (currIndex < index)
        {
            currIndex++;
            currItem = (currItem is not null) ? currItem.next : default;
            toReturn = (currItem is not null) ? currItem.value : default;
        }
        if (toReturn is not null)
            return toReturn;
        else
            throw new Exception("toReturn is null");
    }

    public T Delete(int index)
    {
        if (IsEmpty()) throw new Exception("List is empty!");
        if (index >= length) throw OutOfBoundsException;
        length--;
        int currIndex = 0;
        Node<T> currItem = head;
        Node<T>? prevItem = null;
        T? toReturn = currItem.value;
        while (currIndex < index)
        {
            currIndex++;
            prevItem = currItem;
            currItem = currItem.next;
            toReturn = currItem.value;
        }
        if (prevItem != null)
        {
            prevItem.next = currItem.next;
            if (currItem.next is null) tail = prevItem;
        }
        else
        {
            head = currItem.next;
        }
        if (toReturn is not null)
            return toReturn;
        else
            throw new Exception("toReturn is null");
    }

    public void Display()
    {
        if (length == 0)
        {
            Console.WriteLine("[]");
            return;
        }
        string output = "[";
        Node<T> currItem = head;
        do
        {
            output += currItem.value + ", ";
            currItem = currItem.next;
        }
        while (currItem != null);
        output = output[..^2] + "]";
        Console.WriteLine(output);
    }

    // hopefully this will mean foreach loops work:
    public IEnumerator<T> GetEnumerator()
    {
        current = head;
        while (current is not null)
        {
            yield return current.value;
            current = current.next;
        }
    }
}
