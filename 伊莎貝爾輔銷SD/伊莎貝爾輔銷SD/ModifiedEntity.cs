﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伊莎貝爾輔銷SD
{
    public class ModifiedEntity<TEntity>
    {      
        public Action<TEntity> Modifier { get; set; }
    }
}
