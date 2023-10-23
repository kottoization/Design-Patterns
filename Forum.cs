using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class Forum
    {
        private List<Comment> acceptedComments = new List<Comment>();

        public void addComments(Comment c)
        {
            acceptedComments.Add(c);
        }

        public void printAcceptedComments()
        {
            for(int i = 0; i < acceptedComments.Count; i++)
            {
                int index = i + 1;
                Comment tmpComment = acceptedComments[i];
                Console.WriteLine($"Komentarz numer {index} po moderacji : {tmpComment.GetContent()}");
            }
        }
    }
}
