﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotGame.Graphics
{
    public interface IRasterizerState : IGraphicsObject
    {
        RasterizerStateInfo Info { get; }
    }
}