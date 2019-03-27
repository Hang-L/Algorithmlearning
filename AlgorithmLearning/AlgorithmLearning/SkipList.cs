using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLearning
{
    public sealed class SkipList
    {
        private static int MAX_VALUE = 16;

        private int levelCount = 1;
        private Node head = new Node();
        private Random r = new Random();

        public Node Find(int value)
        {
            Node p = head;
            for (int i = levelCount - 1; i >= 0; --i)
            {
                while (p.forwards[i] != null && p.forwards[i].data < value)
                {
                    p = p.forwards[i];
                }
            }
            if (p.forwards[0] != null && p.forwards[0].data == value)
            {
                return p.forwards[0];
            }
            else
            {
                return null;
            }
        }

        public void Insert(int value)
        {
            int level = RandomLevel();
            Node newNode = new Node();
            newNode.data = value;
            newNode.maxLevel = level;
            Node[] update = new Node[level];
            for (int i = 0; i < level; i++)
            {
                update[i] = head;
            }
            Node p = head;
            for (int i = level - 1; i >= 0; --i)
            {
                while (p.forwards[i] != null && p.forwards[i].data < value)
                {
                    p = p.forwards[i];
                }
                update[i] = p;
            }
            for (int i = 0; i < level; ++i)
            {
                newNode.forwards[i] = update[i].forwards[i];
                update[i].forwards[i] = newNode;
            }
            if (levelCount < level)
            {
                levelCount = level;
            }
        }

        public void Delete(int value)
        {
            Node[] update = new Node[levelCount];
            Node p = head;
            for (int i=levelCount-1;i>=0;--i)
            {
                while (p.forwards[i]!=null&&p.forwards[i].data<value)
                {
                    p=p.forwards[i];
                }
                update[i] = p;
            }
            if (p.forwards[0]!=null&&p.forwards[0].data==value)
            {
                for (int i=levelCount-1;i>=0;--i)
                {
                    if (update[i].forwards[i]!=null&&update[i].forwards[i].data==value)
                    {
                        update[i].forwards[i] = update[i].forwards[i].forwards[i];
                    }
                }
            }
        }

        private int RandomLevel()
        {
            int level = 1;
            for (int i=1;i<MAX_VALUE; ++i)
            {
                if (r.Next()%2==1)
                {
                    level++;
                }
            }
            return level;
        }
        public class Node {
            public int data = -1;
            public  Node[] forwards = new Node[MAX_VALUE];
            public int maxLevel = 0;
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("{ data: ");
                builder.Append(data);
                builder.Append("; levels: ");
                builder.Append(maxLevel);
                builder.Append(" }");

                return builder.ToString();
            }

        }
    }
}
