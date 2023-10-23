using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Comment
    {
        private string content;
        
        public Comment(string content)
        {
            this.content = content;
        }

        public void RemoveWord(string word)
        {
            string[] words = this.content.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(word))
                {
                    words[i] = new string('*', words[i].Length);
                }
            }
            this.content = string.Join(" ", words);
        }

        public string GetContent()
        {
            return content;
        }
    }

}
