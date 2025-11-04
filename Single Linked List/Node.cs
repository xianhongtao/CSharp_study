namespace Single_Linked_List
{
    class Node<T>
    {
        public T? data;
        public Node<T>? next;
        public Node<T>? previous;
        public Node()
        {
            this.next = null;
        }
        public Node(T data)
        {
            this.previous = null;
            this.data = data;
            this.next = null;
        }
    }
}
