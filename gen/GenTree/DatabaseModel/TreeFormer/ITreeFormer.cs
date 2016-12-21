﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.TreeFormer
{
    public interface ITreeFormer
    {
        IDictionary<Int32, Person> FormTree(Int32 code);
    }
}
