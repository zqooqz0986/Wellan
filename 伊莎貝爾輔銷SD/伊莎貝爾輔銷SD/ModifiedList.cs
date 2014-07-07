using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace 伊莎貝爾輔銷SD
{
    public class ModifiedList<TEntity> : List<TEntity> where TEntity : class, INotifyPropertyChanged
    {
        public ModifiedList(
            IEnumerable<TEntity> collection,
            Action<List<TEntity>, TEntity> modifier,
            Action<List<TEntity>, TEntity> remover)
            : base(collection)
        {
            this.Modifier = modifier;            
            this.Remover = remover;

            var handler = new PropertyChangedEventHandler((sender, arg) => 
            {
                var entity = sender as TEntity;
                if (entity != null)
                {
                    this.Modifier(this, entity);
                }                
            });

            var list = collection.ToList();

            list.ForEach((x)=> x.PropertyChanged += handler);
        }

        public Action<List<TEntity>, TEntity> Remover { get; set; }

        public Action<List<TEntity>, TEntity> Modifier { get; set; }

        public new void RemoveAt(int index)
        {
            this.Remover(this, this[index]);
        }
    }
}