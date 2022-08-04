using Framework.Core.Domain;
using Framework.Core.Persistence;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Framework.Domain
{
    [Serializable()]
    public abstract class EntityBase<TEntity> : IEntityBase, ICloneable<TEntity> where TEntity : class
    {
        private IEntityIdGenerator<TEntity> entityIdGenerator = null;


        public EntityBase()
        {
        }


        public EntityBase(IEntityIdGenerator<TEntity> entityIdGenerator)
        {
            this.entityIdGenerator = entityIdGenerator;
        }


        public long Id { get; private set; }


        public TEntity ShallowCopy()
        {
            return (TEntity)MemberwiseClone();
        }


        public TEntity DeepCopy()
        {
            using (var stream = new MemoryStream())
            {
                var dcs = new DataContractSerializer(typeof(TEntity));
                dcs.WriteObject(stream, this);
                stream.Position = 0;

                return (TEntity)dcs.ReadObject(stream);
            }
        }


        protected void SetIdGenerator(IEntityIdGenerator<TEntity> entityIdGenerator)
        {
            this.entityIdGenerator = entityIdGenerator;
        }


        protected void SetId()
        {
            if (entityIdGenerator == null)
            {
                throw new System.Exception(
                    "IEntityIdGenerator is Not Implemented or you forgot to put base(entityIdGenerator)");
            }

            Id = entityIdGenerator.GetNewId();
        }


        protected void SetId(long id)
        {
            Id = id;
        }
    }
}
