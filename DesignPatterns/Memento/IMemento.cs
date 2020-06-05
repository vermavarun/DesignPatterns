using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Memento
{
    public interface IMemento
    {
        string GetName();

        string GetState();

        DateTime GetDate();
    }
}
