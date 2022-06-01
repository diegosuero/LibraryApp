using System.Collections.Generic;
using System.Linq;

namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public abstract class Model<E,M>
        where E : class
        where M : Model<E,M>, new()  
    {
        public static List<M> ToModel(List<E> entities)
        {
            return entities.Select(x => ToModel(x)).ToList();
        }

        public static M ToModel(E entity)
        {
            if (entity == null) return null;
            return new M().SetModel(entity);
        }

        public static E ToEntity(M model)
        {
            if (model == null) return null;
            return model.ToEntity();
        }

        public static IEnumerable<E> ToEntity(IEnumerable<M> models)
        {
            return models.Select(x => ToEntity(x));
        }


        public abstract E ToEntity();

        protected abstract M SetModel(E entity);
    }
}