using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace 伊莎貝爾輔銷SD
{
    public class ModifiedList<TEntity> : List<TEntity> where TEntity :  ModifiedEntity<TEntity>
    {
        public ModifiedList(
            IEnumerable<TEntity> collection,
            Action<TEntity> modifier,
            Action<List<TEntity>, TEntity> remover)
            : base(collection)
        {                      
            this.Remover = remover;

            var list = collection.ToList();

            list.ForEach((x) => x.Modifier = modifier);
        }

        public Action<List<TEntity>, TEntity> Remover { get; set; }

        public new void RemoveAt(int index)
        {
            this.Remover(this, this[index]);
        }
    }
}