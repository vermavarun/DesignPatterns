using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Visitor
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }
}
