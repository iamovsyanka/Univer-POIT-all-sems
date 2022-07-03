using System;
using System.Collections.Generic;

namespace Lab5
{
    public class Publishing : Author
    {
        private List<Author> authors = new List<Author> { };
        private int Count => authors.Count;

        public Publishing() => authors = new List<Author> { };

        public void Add(Author author) => authors.Add(author);

        public void RemoveAt(int index)
        {
            if (index > authors.Count || index < 0)
            {
                Console.WriteLine("");
            }
            authors.RemoveAt(index);
        }

        public void Clear() => authors.Clear();

        public Author this[int index]
        {
            get
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }

                return (Author)authors[index];
            }
            set
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }
                authors[index] = value;
            }
        }

        public override string ToString() => $"Количество авторов, печатающихcя в издательстве, {this.authors.Count}";
        
        public void Search(string alias)
        {
            for (int i = 0; i < Count; i++)
            {
                if (authors[i].CreateAlias() == alias)
                {
                    Console.WriteLine("Это автор есть в базе");
                }
                else
                {
                    Console.WriteLine("Автора в базе нет");
                }

            }
        }    
    }
}
