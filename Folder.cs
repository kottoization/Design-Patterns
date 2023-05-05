using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern1
{
    internal class Folder : IComponent
    {
        public string name;
        private List<IComponent> _components = new List<IComponent>();
       
        public Folder(string name)
        {
            this.name = name;
        }

        public void AddChild(IComponent child)
        {
            this._components.Add(child);
        }

        public void RemoveChild(IComponent child)
        {
            this._components.Remove(child);
        }

        public int GetNumberOfEmails()
        {
            int sum = 0;
            foreach(var component in this._components) 
               sum +=component.GetNumberOfEmails();
            return sum;
        }

        public string PrintStructure()
        {
            string tab = "\t";
            string result = "";
            result += this.name;
            result += Environment.NewLine;

            foreach(IComponent c in this._components)
            {
                result += tab;
                result += c.PrintStructure();
                result += Environment.NewLine;
            }
            return result;
        }
    }
}
