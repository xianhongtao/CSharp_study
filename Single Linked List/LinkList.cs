namespace Single_Linked_List
{
    public class LinkList<T>
    {
        Node<T> head;
        Node<T> tail;
        int Size { set; get; } = 0;
        public LinkList()
        {
            head = new Node<T>();
            tail = new Node<T>();
            head.next = tail;
            tail.previous = head;
        }

        public void LinkListAddToEnd(T input)
        {
            if (tail == null || tail.previous == null)
            {
                throw new InvalidOperationException("链表为空或没有前一个节点。");
            }
            Node<T> node = new Node<T>();
            node.data = input;
            tail.previous.next = node;
            node.previous = tail.previous;
            node.next = tail;
            tail.previous = node;
            Size++;
        }
        public void SetElement(int index, T input)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }
            if (head.next == null)
            {
                throw new InvalidOperationException("链表为空。");
            }
            Node<T>? current = head.next;
            for (int i = 0; i < index; i++)
            {
                if (current.next == null)
                {
                    throw new InvalidOperationException("未找到指定索引的节点。");
                }
                current = current.next;
            }
            current.data = input;
        }

        public T? GetElement(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }
            if (head.next == null)
            {
                throw new InvalidOperationException("链表为空。");
            }
            Node<T>? current = head.next;
            for (int i = 0; i < index; i++)
            {
                if (current.next == null)
                {
                    throw new InvalidOperationException("未找到指定索引的节点。");
                }
                current = current.next;
            }

            return current.data;
        }
        public int GetSize()
        {
            return Size;
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public void InsertAtIndex(int index, T input)
        {
            if (index < 0 || index > Size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index.");
            }
            if (head.next == null)
            {
                throw new InvalidOperationException("链表为空。");
            }
            Node<T>? current = head;
            Node<T> newNode = new Node<T>(input);
            for (int i = 0; i < index; i++)
            {
                if (current.next == null)
                {
                    throw new InvalidOperationException("未找到指定索引的节点。");
                }
                current = current.next;
            }
            current.next = newNode;
            newNode.previous = current;
            newNode.next = current.next;
            current.next.previous = newNode;
        }
    }
}
