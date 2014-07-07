using System;
using System.Collections.Generic;

namespace 伊莎貝爾輔銷SD
{
    public class ModifiedList<TEntity> : List<TEntity> where TEntity : class
    {
        public ModifiedList(
            IEnumerable<TEntity> collection,
            Action<List<TEntity>, TEntity> modifier,
            Action<List<TEntity>, TEntity> remover)
            : base(collection)
        {
            this.Modifier = modifier;
            this.Remover = remover;
        }

        public Action<List<TEntity>, TEntity> Remover { get; set; }

        public Action<List<TEntity>, TEntity> Modifier { get; set; }

        public new void RemoveAt(int index)
        {
            this.Remover(this, this[index]);
        }

        public void ModifyAt(int index)
        {
            this.Modifier(this, this[index]);
        }
    }
}