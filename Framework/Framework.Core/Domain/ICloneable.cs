using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.Domain
{
    public interface ICloneable<T>
    {
        T ShallowCopy();
        T DeepCopy();
    }
}
