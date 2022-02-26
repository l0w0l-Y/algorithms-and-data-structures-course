using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    // Circular list of participants.
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        private ParticipantsData<T> _head;
        private ParticipantsData<T> _tail;
        public int Count;

        // Add a participant to the list.
        public void Add(T data)
        {
            var member = new ParticipantsData<T>(data);
            if (_head == null)
            {
                _head = member;
                _tail = member;
                _tail.Next = _head;
            }
            else
            {
                member.Next = _head;
                _tail.Next = member;
                _tail = member;
            }

            Count++;
        }

        // Add participants to the list.
        public void Add(IEnumerable<T> data)
        {
            foreach (var participant in data)
                Add(participant);
        }

        // Remove a participant from the list.
        public void Remove(T data)
        {
            var current = _head;
            ParticipantsData<T> previous = null;
            do
            {
                if (current.Gender.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == _tail)
                            _tail = previous;
                    }
                    else
                    {
                        if (Count == 1)
                        {
                            _head = _tail = null;
                        }
                        else
                        {
                            _head = current.Next;
                            _tail.Next = current.Next;
                        }
                    }

                    Count--;
                    break;
                }

                previous = current;
                current = current.Next;
            } while (current != _head);
        }

        // Merge two lists.
        public static CircularLinkedList<string> Merge(CircularLinkedList<string> firstList,
            CircularLinkedList<string> secondList)
        {
            firstList._tail.Next = secondList._head;
            secondList._tail.Next = firstList._head;
            return firstList;
        }

        // Divides the list into 2 lists, the first includes participants with a key word, the other includes the rest.
        public static (CircularLinkedList<string>, CircularLinkedList<string>) DivideIntoTwoParts(
            CircularLinkedList<string> startedList, string keyword)
        {
            var firstList = new CircularLinkedList<string>();
            var secondList = new CircularLinkedList<string>();
            foreach (var str in startedList)
            {
                if (str == keyword)
                    firstList.Add(str);
                else
                    secondList.Add(str);
            }

            return (firstList, secondList);
        }

        // Sorts the list, all participants of a certain type are included in the beginning, then another.
        public static CircularLinkedList<string> Sorting(CircularLinkedList<string> startedList, string type)
        {
            var sortedlist = new CircularLinkedList<string>();
            foreach (var element in startedList)
                if (element.Equals(type))
                    sortedlist.Add(element);
            foreach (var element in startedList)
                if (!element.Equals(type))
                    sortedlist.Add(element);
            return sortedlist;
        }

        // Delete each element with coefficient index.
        public static CircularLinkedList<string> Deleting(CircularLinkedList<string> list, int coefficient)
        {
            var deletedList = new CircularLinkedList<string>();
            for (var i = 0; i < deletedList.Count; i++)
            {
                if (i + 1 % coefficient != 0)
                    deletedList.Add(list.ElementAt(i));
            }

            return deletedList;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;
            do
            {
                if (current == null) continue;
                yield return current.Gender;
                current = current.Next;
            } while (current != _head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}